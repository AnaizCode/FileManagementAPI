using File.Database.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File.Database.Repository.Implementation
{
    public  class FilesRepository: IFilesRepository
    {
        private DBFileContext context;

        public FilesRepository()
        {
            context = new DBFileContext();
        }


        public bool AddFile(FileDB file)
        {
            context.Files.Add(file);

            context.SaveChanges();
            return true;
        }

        public FileDB GetFile(string varName)
            {
            return context.Files
                .Where(x => x.FileName == varName)
                .FirstOrDefault();
        }

        public bool DeleteFile(string varName) {

            try
            {
                var fileToDelete = context.Files.FirstOrDefault(x => x.FileName == varName);

                if (fileToDelete != null)
                {
                    context.Files.Remove(fileToDelete);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the file: " + ex.Message);
                return false;
            }
        }

        public bool UpdateFile(string varName, string newName)
        {
            var _file = context.Files
        .Where(x => x.FileName == varName)
        .OrderBy(x => x.FileId) 
        .FirstOrDefault();

            if (_file != null)
            {
                _file.FileName = newName;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateFile(string varName, FileDB file)
        {
            var _file = context.Files
          .Where(x => x.FileName == varName)
          .OrderBy(x => x.FileId) 
          .FirstOrDefault();

            if (_file != null)
            {
                _file.BinaryFile = file.BinaryFile;
                context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
