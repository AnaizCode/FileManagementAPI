using FileManagementAPI.Database;
using FileManagementAPI.Services.Models;
using FileManagementAPI.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace FileManagementAPI.Services.Services.Implementation.Converter
{
    public class FileConverters : IFileConverters
    {

        public FileDB convertToModelSaveFile(RequestSaveFileModel requestSaveFileModel)
        {

            return new FileDB()
            {
                FileName = requestSaveFileModel.FileName,
                FileId = requestSaveFileModel.FileId,
                BinaryFile = ConvertFromBinaryToString(ConvertIFormFileToBinary(requestSaveFileModel.File))
            };
        }

        private   string ConvertFromBinaryToString(byte[] binaryData)
        {

            string text = Convert.ToBase64String(binaryData);
            return text;
        }

        private   byte[] ConvertIFormFileToBinary(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
      
    }
}
