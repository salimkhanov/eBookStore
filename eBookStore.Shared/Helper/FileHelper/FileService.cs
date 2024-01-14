using Microsoft.AspNetCore.Http;

namespace eBookStore.Shared.Helper.FileHelper;

public class FileService : IFileService
{
    public string Upload(IFormFile file)
    {
        string fileName = Path.GetFileNameWithoutExtension(file.FileName);
        string fileExtension = Path.GetExtension(file.FileName);
        string uniqueFileName = fileName + "_" + Guid.NewGuid().ToString() + fileExtension;

        string filePath = Path.Combine( @"D:\eBook", uniqueFileName);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }
        return filePath;
    }

    public bool Delete(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return false;
        }
        var path = Path.Combine(fileName);

        if (File.Exists(path))
        {
            File.Delete(path);
            return true;
        }
        return false;
    }

    public bool IsImage(IFormFile file)
    {

        if (file.ContentType.Contains("image"))
        {
            return true;
        }
        return false;
    }
}
