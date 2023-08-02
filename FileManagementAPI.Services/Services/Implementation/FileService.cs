using FileManagementAPI.Services.Models;
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
        private readonly IFileConverters _fileConverters;

        public FileService(IFilesRepository repository, IFileConverters fileConverters)
        {
            _repository = repository;
            _fileConverters = fileConverters;
        }

        public FileService(IFilesRepository repository)
        {
            _repository = repository;
        }

        public bool SaveFile(IFormFile file) {
            RequestSaveFileModel requestModel = new RequestSaveFileModel();

            requestModel.FileName = file.FileName;
            requestModel.File = file;
            FileDB filedb_ = _fileConverters.convertToModelSaveFile(requestModel);
            _repository.AddFile(filedb_);


            return true; }


        public FileDB GetFile(string varName)
        {
            return _repository.GetFile(varName);

        }

        public bool DeleteFile(string varName) {


            return _repository.DeleteFile(varName);
            
        }

        public bool UpdateFile(string varName, string newName) {


            return _repository.UpdateFile( varName, newName);
        }

        public bool UpdateFile(string varName, IFormFile file) {
            RequestSaveFileModel requestModel = new RequestSaveFileModel();
            requestModel.FileName = file.FileName;
            requestModel.File = file;
            FileDB filedb_ = _fileConverters.convertToModelSaveFile(requestModel);
            return _repository.UpdateFile(varName, filedb_); 
        }


    }
}
