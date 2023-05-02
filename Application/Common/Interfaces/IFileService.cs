using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(string additionalPath, IFormFile file, string fileName, CancellationToken cancellationToken);
        bool DeleteFile(string path);
        FileStream GetFile(string path, string fileName);
    }
}
