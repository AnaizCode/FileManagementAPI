using FileManagementAPI.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FileManagementAPI.Database;
using FileManagementAPI.Database.Repository.Interface;

namespace FileManagementAPI.Services.Services.Implementation
{
    public class FileService: IFileService
    {

        private readonly IFilesRepository _repository;

        public FileService(IFilesRepository repository)
        {
            _repository = repository;
        }
        public bool SaveFile(FileDB file) {
           
           return _repository.AddFile(file); 
        }

        public FileDB GetFile(string varName)
        {
            return _repository.GetFile(varName);

        }

        public bool DeleteFile(string varName) 
        {
            return _repository.DeleteFile(varName);    
        }

        public bool UpdateFile(string varName, string newName) 
        {
            return _repository.UpdateFile( varName, newName);
        }

        public bool UpdateFile(string varName, FileDB file) {
           
            return _repository.UpdateFile(varName, file); 
        }
    }
}
