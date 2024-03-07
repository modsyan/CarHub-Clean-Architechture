using Mac.CarHub.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Mac.CarHub.Application.Common.Interfaces;

public interface IFileService
{
    public Task<UploadedFile> SaveToDiskAsync(IFormFile file, CancellationToken cancellationToken = default);
    
    public Task<UploadedFile> SaveToDiskAsync(byte[] file, string fileName, CancellationToken cancellationToken = default);
    public Task<bool> DeleteFileAsync(UploadedFile file, CancellationToken cancellationToken = default);
    public Task<string> GetFileUrl(UploadedFile file);
}
