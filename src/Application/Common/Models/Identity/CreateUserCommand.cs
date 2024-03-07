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

    public UploadedFile? DefaultAvatar { get; private set; }

    public string RoleId { get; private set; } = Roles.User;

    public CreateUserCommand(
        string userName,
        string password,
        string firstName,
        string? lastName,
        IFormFile personalPhoto,
        string roleId)
    {
        UserName = userName;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        PersonalPhoto = personalPhoto;
        RoleId = roleId;
    }

    public CreateUserCommand(
        string userName,
        string password,
        string? firstName,
        string lastName,
        UploadedFile defaultAvatar,
        string roleId)
    {
        UserName = userName;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        RoleId = roleId;
        DefaultAvatar = defaultAvatar;
    }

    public CreateUserCommand(
        string userName,
        string password,
        string fullName,
        string roleId)
    {
        var names = fullName.Split(' ', 2);

        UserName = userName;
        Password = password;
        FirstName = names[0];
        LastName = names.Length > 1 ? names[1] : string.Empty;
        RoleId = roleId;
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
