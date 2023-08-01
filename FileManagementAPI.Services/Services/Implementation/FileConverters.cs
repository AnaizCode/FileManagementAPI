using File.Database;
using File.Services.Converter.Interfaces;
using File.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Text;

namespace File.Services.Converter.Implementation
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
