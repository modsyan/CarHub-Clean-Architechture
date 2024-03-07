using Mac.CarHub.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Mac.CarHub.Application.Common.Interfaces;

public interface IAvatarGeneratorService
{
    Task<UploadedFile> GetBrokerAvatar();
    Task<UploadedFile> GetAdminAvatar();
    Task<UploadedFile> GetUserAvatar();
    Task<UploadedFile?> AvatarsWithInitialsFromNames(string firstName, string lastName);
    Task<UploadedFile?> GetRandomAvatar();
}
