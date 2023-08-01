using File.Database;
using Microsoft.AspNetCore.Http;

namespace File.Services.Services.Interfaces
{
   public interface IFileService
    {
       bool SaveFile(IFormFile file);
       FileDB GetFile(string varName);
       bool DeleteFile(string varName);
       public bool UpdateFile(string varName, string newName);

       public bool UpdateFile(string varName, IFormFile file);

    }
}