using System.Diagnostics;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Mac.CarHub.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;

namespace Mac.CarHub.Web.Endpoints;

public class AuthenticationDev : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            .MapIdentityApi<ApplicationUser>();
        ;

        //     var timeProvider = app.ServiceProvider.GetRequiredService<TimeProvider>();
        //     var bearerTokenOptions = app.ServiceProvider.GetRequiredService<IOptionsMonitor<BearerTokenOptions>>();
        //     var emailSender = app.ServiceProvider.GetRequiredService<IEmailSender<ApplicationUser>>();
        //     var linkGenerator = app.ServiceProvider.GetRequiredService<LinkGenerator>();
        //
        // // We'll figure out a unique endpoint name based on the final route pattern during endpoint generation.
        // string? confirmEmailEndpointName = null;

        // var accountGroup = app.MapGroup("/manage").RequireAuthorization();
        //
        // accountGroup.MapPost("/2fa", async Task<Results<Ok<TwoFactorResponse>, ValidationProblem, NotFound>>
        // (ClaimsPrincipal claimsPrincipal, [FromBody] TwoFactorRequest tfaRequest,
        //     [FromServices] IServiceProvider sp) =>
        // {
        //     var signInManager = sp.GetRequiredService<SignInManager<TUser>>();
        //     var userManager = signInManager.UserManager;
        //     if (await userManager.GetUserAsync(claimsPrincipal) is not { } user)
        //     {
        //         return TypedResults.NotFound();
        //     }
        //
        //     if (tfaRequest.Enable == true)
        //     {
        //         if (tfaRequest.ResetSharedKey)
        //         {
        //             return CreateValidationProblem("CannotResetSharedKeyAndEnable",
        //                 "Resetting the 2fa shared key must disable 2fa until a 2fa token based on the new shared key is validated.");
        //         }
        //         else if (string.IsNullOrEmpty(tfaRequest.TwoFactorCode))
        //         {
        //             return CreateValidationProblem("RequiresTwoFactor",
        //                 "No 2fa token was provided by the request. A valid 2fa token is required to enable 2fa.");
        //         }
        //         else if (!await userManager.VerifyTwoFactorTokenAsync(user,
        //                      userManager.Options.Tokens.AuthenticatorTokenProvider, tfaRequest.TwoFactorCode))
        //         {
        //             return CreateValidationProblem("InvalidTwoFactorCode",
        //                 "The 2fa token provided by the request was invalid. A valid 2fa token is required to enable 2fa.");
        //         }
        //
        //         await userManager.SetTwoFactorEnabledAsync(user, true);
        //     }
        //     else if (tfaRequest.Enable == false || tfaRequest.ResetSharedKey)
        //     {
        //         await userManager.SetTwoFactorEnabledAsync(user, false);
        //     }
        //
        //     if (tfaRequest.ResetSharedKey)
        //     {
        //         await userManager.ResetAuthenticatorKeyAsync(user);
        //     }
        //
        //     string[]? recoveryCodes = null;
        //     if (tfaRequest.ResetRecoveryCodes ||
        //         (tfaRequest.Enable == true && await userManager.CountRecoveryCodesAsync(user) == 0))
        //     {
        //         var recoveryCodesEnumerable = await userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10);
        //         recoveryCodes = recoveryCodesEnumerable?.ToArray();
        //     }
        //
        //     if (tfaRequest.ForgetMachine)
        //     {
        //         await signInManager.ForgetTwoFactorClientAsync();
        //     }
        //
        //     var key = await userManager.GetAuthenticatorKeyAsync(user);
        //     if (string.IsNullOrEmpty(key))
        //     {
        //         await userManager.ResetAuthenticatorKeyAsync(user);
        //         key = await userManager.GetAuthenticatorKeyAsync(user);
        //
        //         if (string.IsNullOrEmpty(key))
        //         {
        //             throw new NotSupportedException("The user manager must produce an authenticator key after reset.");
        //         }
        //     }
        //
        //     return TypedResults.Ok(new TwoFactorResponse
        //     {
        //         SharedKey = key,
        //         RecoveryCodes = recoveryCodes,
        //         RecoveryCodesLeft = recoveryCodes?.Length ?? await userManager.CountRecoveryCodesAsync(user),
        //         IsTwoFactorEnabled = await userManager.GetTwoFactorEnabledAsync(user),
        //         IsMachineRemembered = await signInManager.IsTwoFactorClientRememberedAsync(user),
        //     });
        // });
        //
        // accountGroup.MapGet("/info", async Task<Results<Ok<InfoResponse>, ValidationProblem, NotFound>>
        //     (ClaimsPrincipal claimsPrincipal, [FromServices] IServiceProvider sp) =>
        // {
        //     var userManager = sp.GetRequiredService<UserManager<ApplicationUser>>();
        //     if (await userManager.GetUserAsync(claimsPrincipal) is not { } user)
        //     {
        //         return TypedResults.NotFound();
        //     }
        //
        //     return TypedResults.Ok(await CreateInfoResponseAsync(user, userManager));
        // });
        //
        // accountGroup.MapPost("/info", async Task<Results<Ok<InfoResponse>, ValidationProblem, NotFound>>
        // (ClaimsPrincipal claimsPrincipal, [FromBody] InfoRequest infoRequest, HttpContext context,
        //     [FromServices] IServiceProvider sp) =>
        // {
        //     var userManager = sp.GetRequiredService<UserManager<TUser>>();
        //     if (await userManager.GetUserAsync(claimsPrincipal) is not { } user)
        //     {
        //         return TypedResults.NotFound();
        //     }
        //
        //     if (!string.IsNullOrEmpty(infoRequest.NewEmail) && !_emailAddressAttribute.IsValid(infoRequest.NewEmail))
        //     {
        //         return CreateValidationProblem(
        //             IdentityResult.Failed(userManager.ErrorDescriber.InvalidEmail(infoRequest.NewEmail)));
        //     }
        //
        //     if (!string.IsNullOrEmpty(infoRequest.NewPassword))
        //     {
        //         if (string.IsNullOrEmpty(infoRequest.OldPassword))
        //         {
        //             return CreateValidationProblem("OldPasswordRequired",
        //                 "The old password is required to set a new password. If the old password is forgotten, use /resetPassword.");
        //         }
        //
        //         var changePasswordResult =
        //             await userManager.ChangePasswordAsync(user, infoRequest.OldPassword, infoRequest.NewPassword);
        //         if (!changePasswordResult.Succeeded)
        //         {
        //             return CreateValidationProblem(changePasswordResult);
        //         }
        //     }
        //
        //     if (!string.IsNullOrEmpty(infoRequest.NewEmail))
        //     {
        //         var email = await userManager.GetEmailAsync(user);
        //
        //         if (email != infoRequest.NewEmail)
        //         {
        //             await SendConfirmationEmailAsync(user, userManager, context, infoRequest.NewEmail, isChange: true);
        //         }
        //     }
        //
        //     return TypedResults.Ok(await CreateInfoResponseAsync(user, userManager));
        // });


    }

    private sealed class IdentityEndpointsConventionBuilder(RouteGroupBuilder inner) : IEndpointConventionBuilder
    {
        private IEndpointConventionBuilder InnerAsConventionBuilder => inner;

        public void Add(Action<EndpointBuilder> convention) => InnerAsConventionBuilder.Add(convention);

        public void Finally(Action<EndpointBuilder> finallyConvention) =>
            InnerAsConventionBuilder.Finally(finallyConvention);
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    private sealed class FromBodyAttribute : Attribute, IFromBodyMetadata
    {
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    private sealed class FromServicesAttribute : Attribute, IFromServiceMetadata
    {
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    private sealed class FromQueryAttribute : Attribute, IFromQueryMetadata
    {
        public string? Name => null;
    }
}
