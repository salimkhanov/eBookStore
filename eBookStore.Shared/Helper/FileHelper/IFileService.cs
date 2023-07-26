using Microsoft.AspNetCore.Http;

namespace eBookStore.Shared.Helper.FileHelper;

public interface IFileService
{
    string Upload(IFormFile file);
    bool Delete(string fileName);
    bool IsImage(IFormFile file);
}
