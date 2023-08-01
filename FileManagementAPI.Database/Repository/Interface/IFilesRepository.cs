using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File.Database.Repository.Interface
{
    public interface IFilesRepository
    {
        public bool AddFile(FileDB file);
        public FileDB GetFile(string varName);

        public bool DeleteFile(string varName);

        public bool UpdateFile(string varName, string newName);

        public bool UpdateFile(string varName,FileDB file);
    }
}
