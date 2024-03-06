using System.Diagnostics;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Mac.CarHub.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using LoginRequest = Mac.CarHub.Application.Common.Models.Identity.LoginRequest;

namespace Mac.CarHub.Web.Endpoints.Authentication;

public class Authentication : EndpointGroupBase
{
    // var timeProvider = app.ServiceProvider.GetRequiredService<TimeProvider>();
    // var bearerTokenOptions = app.ServiceProvider.GetRequiredService<IOptionsMonitor<BearerTokenOptions>>();
    // var emailSender = app.ServiceProvider.GetRequiredService<IEmailSender<ApplicationUser>>();
    // var linkGenerator = app.ServiceProvider.GetRequiredService<LinkGenerator>();

    // We'll figure out a unique endpoint name based on the final route pattern during endpoint generation.
    string? confirmEmailEndpointName = null;

    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            // .MapPost(Authenticate, "/login")
            .MapPost(RefreshToken, "/refresh-token")
            .MapGet(ConfirmEmail, "/confirm-email")
            .MapPost(this.ResendConfirmationEmail, "/resend-confirmation-email")
            .MapPost(ForgotPassword, "/forgot-password")
            .MapPost(this.ResetPassword, "/reset-password")
            .MapPost("/login", async Task<Results<Ok<AccessTokenResponse>, EmptyHttpResult, ProblemHttpResult>>
            ([FromBody] LoginRequest login, [FromQuery] bool? useCookies, [FromQuery] bool? useSessionCookies,
                [FromServices] IServiceProvider sp) =>
            {
                var signInManager = sp.GetRequiredService<SignInManager<ApplicationUser>>();

                var useCookieScheme = (useCookies == true) || (useSessionCookies == true);
                var isPersistent = (useCookies == true) && (useSessionCookies != true);
                signInManager.AuthenticationScheme =
                    useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;

                var result =
                    await signInManager.PasswordSignInAsync(login.UserName, login.Password, isPersistent,
                        lockoutOnFailure: true);

                if (result.RequiresTwoFactor)
                {
                    if (!string.IsNullOrEmpty(login.TwoFactorCode))
                    {
                        result = await signInManager.TwoFactorAuthenticatorSignInAsync(login.TwoFactorCode,
                            isPersistent,
                            rememberClient: isPersistent);
                    }
                    else if (!string.IsNullOrEmpty(login.TwoFactorRecoveryCode))
                    {
                        result = await signInManager.TwoFactorRecoveryCodeSignInAsync(login.TwoFactorRecoveryCode);
                    }
                }

                if (!result.Succeeded)
                {
                    return TypedResults.Problem(result.ToString(), statusCode: StatusCodes.Status401Unauthorized);
                }

                // The signInManager already produced the needed response in the form of a cookie or bearer token.
                return TypedResults.Empty;
            });
    }


    public async Task SendConfirmationEmailAsync(ApplicationUser user, UserManager<ApplicationUser> userManager,
        HttpContext context, string email, bool isChange = false)
    {
        var linkGenerator = context.RequestServices.GetRequiredService<LinkGenerator>();
        var emailSender = context.RequestServices.GetRequiredService<IEmailSender<ApplicationUser>>();

        if (confirmEmailEndpointName is null)
        {
            throw new NotSupportedException("No email confirmation endpoint was registered!");
        }

        var code = isChange
            ? await userManager.GenerateChangeEmailTokenAsync(user, email)
            : await userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        var userId = await userManager.GetUserIdAsync(user);
        var routeValues = new RouteValueDictionary() { ["userId"] = userId, ["code"] = code, };

        if (isChange)
        {
            // This is validated by the /confirmEmail endpoint on change.
            routeValues.Add("changedEmail", email);
        }

        var confirmEmailUrl = linkGenerator.GetUriByName(context, confirmEmailEndpointName, routeValues)
                              ?? throw new NotSupportedException(
                                  $"Could not find endpoint named '{confirmEmailEndpointName}'.");

        await emailSender.SendConfirmationLinkAsync(user, email, HtmlEncoder.Default.Encode(confirmEmailUrl));
    }


    public ValidationProblem CreateValidationProblem(string errorCode, string errorDescription) =>
        TypedResults.ValidationProblem(new Dictionary<string, string[]> { { errorCode, [errorDescription] } });

    public ValidationProblem CreateValidationProblem(IdentityResult result)
    {
        // We expect a single error code and description in the normal case.
        // This could be golfed with GroupBy and ToDictionary, but perf! :P
        Debug.Assert(!result.Succeeded);
        var errorDictionary = new Dictionary<string, string[]>(1);

        foreach (var error in result.Errors)
        {
            string[] newDescriptions;

            if (errorDictionary.TryGetValue(error.Code, out var descriptions))
            {
                newDescriptions = new string[descriptions.Length + 1];
                Array.Copy(descriptions, newDescriptions, descriptions.Length);
                newDescriptions[descriptions.Length] = error.Description;
            }
            else
            {
                newDescriptions = [error.Description];
            }

            errorDictionary[error.Code] = newDescriptions;
        }

        return TypedResults.ValidationProblem(errorDictionary);
    }

    public static async Task<InfoResponse> CreateInfoResponseAsync(ApplicationUser user,
        UserManager<ApplicationUser> userManager)
    {
        return new InfoResponse
        {
            Email = await userManager.GetEmailAsync(user) ??
                    throw new NotSupportedException("Users must have an email."),
            IsEmailConfirmed = await userManager.IsEmailConfirmedAsync(user),
        };
    }


    public static async Task<Results<Ok<AccessTokenResponse>, EmptyHttpResult, ProblemHttpResult>> Authenticate(
        SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
        IWebHostEnvironment webHostEnvironment,
        [FromBody] LoginRequest request, [FromQuery] bool? useCookies, [FromQuery] bool? useSessionCookies)
    {
        var useCookieScheme = (useCookies == true) || (useSessionCookies == true);

        var isPersistent = (useCookies == true) && (useSessionCookies != true);

        signInManager.AuthenticationScheme =
            useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;


        var user = await userManager.FindByNameAsync(request.UserName);

        if (user is null)
        {
            // for development purposes, we don't want to expose the fact that the user does not exist
            return TypedResults.Problem("User not found", statusCode: StatusCodes.Status404NotFound);
            // must return at production unauthorized
            // return TypedResults.Problem(result.ToString(), statusCode: StatusCodes.Status401Unauthorized);
        }

        var roles = await userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email!),
        };

        if (webHostEnvironment.IsDevelopment())
        {
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
        }

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10)
        };

        await signInManager.SignInWithClaimsAsync(user, isPersistent, claims);

        var result = await signInManager.PasswordSignInAsync(request.UserName, request.Password, isPersistent, true);

        if (result.RequiresTwoFactor)
        {
            if (!string.IsNullOrEmpty(request.TwoFactorCode))
            {
                result = await signInManager.TwoFactorAuthenticatorSignInAsync(request.TwoFactorCode, isPersistent,
                    rememberClient: isPersistent);
            }
            else if (!string.IsNullOrEmpty(request.TwoFactorRecoveryCode))
            {
                result = await signInManager.TwoFactorRecoveryCodeSignInAsync(request.TwoFactorRecoveryCode);
            }
        }

        if (!result.Succeeded)
        {
            return TypedResults.Problem(result.ToString(), statusCode: StatusCodes.Status401Unauthorized);
        }

        // The signInManager already produced the needed response in the form of a cookie or bearer token.
        return TypedResults.Empty;
        // return TypedResults.Ok(new AccessTokenResponse
        // {

        // };
    }


    public static async Task<Results<ContentHttpResult, UnauthorizedHttpResult>> ConfirmEmail(
        [FromQuery] string userId,
        [FromQuery] string code,
        [FromQuery] string? changedEmail,
        [FromServices] IServiceProvider sp)

    {
        var userManager = sp.GetRequiredService<UserManager<ApplicationUser>>();
        if (await userManager.FindByIdAsync(userId) is not { } user)
        {
            // We could respond with a 404 instead of a 401 like Identity UI, but that feels like unnecessary information.
            return TypedResults.Unauthorized();
        }

        try
        {
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        }
        catch (FormatException)
        {
            return TypedResults.Unauthorized();
        }

        IdentityResult result;

        if (string.IsNullOrEmpty(changedEmail))
        {
            result = await userManager.ConfirmEmailAsync(user, code);
        }
        else
        {
            // As with Identity UI, email and user name are one and the same. So when we update the email,
            // we need to update the user name.
            result = await userManager.ChangeEmailAsync(user, changedEmail, code);

            if (result.Succeeded)
            {
                result = await userManager.SetUserNameAsync(user, changedEmail);
            }
        }

        if (!result.Succeeded)
        {
            return TypedResults.Unauthorized();
        }

        return TypedResults.Text("Thank you for confirming your email.");
    }
    // )
    // .Add(endpointBuilder =>
    // {
    //     var finalPattern = ((RouteEndpointBuilder)endpointBuilder).RoutePattern.RawText;
    //     confirmEmailEndpointName = $"{nameof(MapIdentityApi)}-{finalPattern}";
    //     endpointBuilder.Metadata.Add(new EndpointNameMetadata(confirmEmailEndpointName));
    // });


    private static async Task<Results<Ok, ValidationProblem>> ForgotPassword(
        [FromBody] ForgotPasswordRequest resetRequest,
        [FromServices] UserManager<ApplicationUser> userManager,
        [FromServices] IEmailSender<ApplicationUser> emailSender)
    {
        var user = await userManager.FindByEmailAsync(resetRequest.Email);

        if (user is not null && await userManager.IsEmailConfirmedAsync(user))
        {
            var code = await userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            await emailSender.SendPasswordResetCodeAsync(user, resetRequest.Email,
                HtmlEncoder.Default.Encode(code));
        }

        // Don't reveal that the user does not exist or is not confirmed, so don't return a 200 if we would have
        // returned a 400 for an invalid code given a valid user email.
        return TypedResults.Ok();
    }

    private static async
        Task<Results<Ok<AccessTokenResponse>, UnauthorizedHttpResult, SignInHttpResult, ChallengeHttpResult>>
        RefreshToken([FromBody] RefreshRequest refreshRequest, [FromServices] IServiceProvider sp)
    {
        var timeProvider = sp.GetRequiredService<TimeProvider>();
        var bearerTokenOptions = sp.GetRequiredService<IOptionsMonitor<BearerTokenOptions>>();

        var signInManager = sp.GetRequiredService<SignInManager<ApplicationUser>>();
        var refreshTokenProtector =
            bearerTokenOptions.Get(IdentityConstants.BearerScheme).RefreshTokenProtector;
        var refreshTicket = refreshTokenProtector.Unprotect(refreshRequest.RefreshToken);

        // Reject the /refresh attempt with a 401 if the token expired or the security stamp validation fails
        if (refreshTicket?.Properties?.ExpiresUtc is not { } expiresUtc ||
            timeProvider.GetUtcNow() >= expiresUtc ||
            await signInManager.ValidateSecurityStampAsync(refreshTicket.Principal) is not ApplicationUser user)

        {
            return TypedResults.Challenge();
        }

        var newPrincipal = await signInManager.CreateUserPrincipalAsync(user);
        return TypedResults.SignIn(newPrincipal, authenticationScheme: IdentityConstants.BearerScheme);
    }

    public async Task<Ok> ResendConfirmationEmail(
        [FromBody] ResendConfirmationEmailRequest resendRequest,
        HttpContext context,
        [FromServices] UserManager<ApplicationUser> userManager)
    {
        if (await userManager.FindByEmailAsync(resendRequest.Email) is not { } user)
        {
            return TypedResults.Ok();
        }

        await SendConfirmationEmailAsync(user, userManager, context, resendRequest.Email);
        return TypedResults.Ok();
    }


    public async Task<Results<Ok, ValidationProblem>>
        ResetPassword([FromBody] ResetPasswordRequest resetRequest,
            [FromServices] UserManager<ApplicationUser> userManager)

    {
        var user = await userManager.FindByEmailAsync(resetRequest.Email);

        if (user is null || !(await userManager.IsEmailConfirmedAsync(user)))
        {
            // Don't reveal that the user does not exist or is not confirmed, so don't return a 200 if we would have
            // returned a 400 for an invalid code given a valid user email.
            return CreateValidationProblem(IdentityResult.Failed(userManager.ErrorDescriber.InvalidToken()));
        }

        IdentityResult result;
        try
        {
            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(resetRequest.ResetCode));
            result = await userManager.ResetPasswordAsync(user, code, resetRequest.NewPassword);
        }
        catch (FormatException)
        {
            result = IdentityResult.Failed(userManager.ErrorDescriber.InvalidToken());
        }

        if (!result.Succeeded)
        {
            return CreateValidationProblem(result);
        }

        return TypedResults.Ok();
    }
}
