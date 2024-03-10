using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Mac.CarHub.Application.Models;

public class CreateUserCommand
{
    public string UserName { get; private set; } = null!;

    public string Password { get; private set; } = null!;

    public string? FirstName { get; private set; }

    public string? LastName { get; private set; }

    public IFormFile? PersonalPhoto { get; private set; } = null!;
    
    public string Email { get; private set; } = null!;

    public UploadedFile? DefaultAvatar { get; private set; }
    
    public string PhoneNumber { get; private set; } = null!;

    public string RoleId { get; private set; } = Roles.User;
    
    public string NationalId { get; private set; } = null!;

    public CreateUserCommand(
        string userName,
        string password,
        string firstName,
        string? lastName,
        string email,
        IFormFile personalPhoto,
        string roleId)
    {
        UserName = userName;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PersonalPhoto = personalPhoto;
        RoleId = roleId;
    }

    public CreateUserCommand(
        string userName,
        string password,
        string? firstName,
        string lastName,
        string email,
        UploadedFile defaultAvatar,
        string roleId)
    {
        UserName = userName;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        RoleId = roleId;
        Email = email;
        DefaultAvatar = defaultAvatar;
    }

    public CreateUserCommand(
        string userName,
        string password,
        string fullName,
        string email,
        string phoneNumber,
        string nationalId,
        string roleId)
    {
        var names = fullName.Split(' ', 2);

        UserName = userName;
        Password = password;
        FirstName = names[0];
        LastName = names.Length > 1 ? names[1] : string.Empty;
        Email = email;
        PhoneNumber = phoneNumber;
        RoleId = roleId;
        NationalId = nationalId;
    }

    public CreateUserCommand WithPersonalPhoto(IFormFile personalPhoto)
    {
        PersonalPhoto = personalPhoto;
        return this;
    }

    public CreateUserCommand WithDefaultAvatar(UploadedFile defaultAvatar)
    {
        DefaultAvatar = defaultAvatar;
        return this;
    }
}
