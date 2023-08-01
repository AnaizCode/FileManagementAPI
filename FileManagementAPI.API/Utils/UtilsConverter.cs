using File.Database;

namespace File.API.Utils
{
    public static class UtilsConverter
    {
        public static IFormFile ConvertDBFileToIFormFile(FileDB dbFile)
        {
            byte[] fileBytes = ConvertFrom64StringToBytes(dbFile.BinaryFile);
            string filename = dbFile.FileName;
            return ConvertBinaryFileToIFormFile(fileBytes, filename);
        }

        public static byte[] ConvertFrom64StringToBytes(string binaryString)
        {
            return Convert.FromBase64String(binaryString);
        }
        private static IFormFile ConvertBinaryFileToIFormFile(byte[] fileBytes, string filename)
        {

            using (MemoryStream memoryStream = new MemoryStream(fileBytes))
            {
                string contentType = "application/pdf";
                IFormFile file = new FormFile(memoryStream, 0, memoryStream.Length, contentType, filename);
                return file;
            }
        }
    }
}
