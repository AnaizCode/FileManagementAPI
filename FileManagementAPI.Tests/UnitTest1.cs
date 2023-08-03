using FileManagementAPI.Services.Services.Interfaces;
using FileManagementAPI.Services.Services.Implementation;
using Xunit;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using NSubstitute;
using Microsoft.AspNetCore.Http;

using System.IO;
using Moq;
using System.Text;
using FileManagementAPI.Database.Repository.Interface;
using FileManagementAPI.Database;
using AutoFixture.Xunit2;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Internal;

namespace File.Tests
{
    [CollectionDefinition("Tests", DisableParallelization = true)]

    public class UnitTest1
    {
        private IFileService _FileService;
        private IFormFile _Formfile;
        private IFilesRepository _filesRepository;

        public UnitTest1()
        {
            //this._FileService = Substitute.For<IFileService>();
            this._filesRepository = Substitute.For<IFilesRepository>();
            this._FileService = Substitute.For<IFileService>();
        }

        [Theory, AutoData]
        public void ServiceSaveFileWorks(FileDB fileDBReplicate)
        {
            //Arrange
            _filesRepository.AddFile(fileDBReplicate).Returns(true);
            var fileService = new FileService(_filesRepository);

            // Act
            var result = fileService.SaveFile(fileDBReplicate);

            //Asert
            Assert.NotNull(result);
            Assert.IsType<bool>(result);
            Assert.Equal(true, result);

        }

        [Theory, AutoData]
        public void ServiceSaveFileFails(FileDB fileDBReplicate)
        {
            //Arrange
            _filesRepository.AddFile(fileDBReplicate).Returns(false);
            var fileService = new FileService(_filesRepository);

            // Act
            var result = fileService.SaveFile(fileDBReplicate);

            //Asert
            Assert.NotNull(result);
            Assert.IsType<bool>(result);
            Assert.Equal(false, result);

        }

        [Theory, AutoData]
        public void ServiceGetFileWorks(string varName, FileDB fileDBReplicate)
        {
            //Arrange
            _filesRepository.GetFile(varName).Returns<FileDB>(fileDBReplicate);
            var fileService = new FileService(_filesRepository);

            // Act
            FileDB result = fileService.GetFile(varName);

            //Asert
            Assert.NotNull(result);
            Assert.IsType<FileDB>(result);
            Assert.Equal(fileDBReplicate, result);

        }

        [Theory, AutoData]
        public void ServiceDeleteFileWorks(string varName)
        {
            //Arrange
            _filesRepository.DeleteFile(varName).Returns(true);
            var fileService = new FileService(_filesRepository);

            // Act
            var result = fileService.DeleteFile(varName);

            //Asert
            Assert.NotNull(result);
            Assert.IsType<bool>(result);
            Assert.Equal(true, result);

        }

        [Theory, AutoData]
        public void ServiceDeleteFileFails(string varName)
        {
            //Arrange
            _filesRepository.DeleteFile(varName).Returns(false);
            var fileService = new FileService(_filesRepository);

            // Act
            var result = fileService.DeleteFile(varName);

            //Asert
            Assert.NotNull(result);
            Assert.IsType<bool>(result);
            Assert.Equal(false, result);

        }

        [Theory, AutoData]
        public void ServiceUpdateFileNameWorks(string varName, string newName)
        {
            //Arrange
            _filesRepository.UpdateFile(varName, newName).Returns(true);
            var fileService = new FileService(_filesRepository);

            // Act
            var result = fileService.UpdateFile(varName, newName);

            //Asert
            Assert.NotNull(result);
            Assert.IsType<bool>(result);
            Assert.Equal(true, result);

        }

        [Theory, AutoData]
        public void ServiceUpdateFileNameFails(string varName, string newName)
        {
            //Arrange
            _filesRepository.UpdateFile(varName, newName).Returns(false);
            var fileService = new FileService(_filesRepository);

            // Act
            var result = fileService.UpdateFile(varName, newName);

            //Asert
            Assert.NotNull(result);
            Assert.IsType<bool>(result);
            Assert.Equal(false, result);

        }

        [Theory, AutoData]
        public void ServiceUpdateFileContentWorks(string varName, FileDB file)
        {
            //Arrange
            _filesRepository.UpdateFile(varName, file).Returns(true);
            var fileService = new FileService(_filesRepository);

            // Act
            var result = fileService.UpdateFile(varName, file);

            //Asert
            Assert.NotNull(result);
            Assert.IsType<bool>(result);
            Assert.Equal(true, result);

        }

        [Theory, AutoData]
        public void ServiceUpdateFileContentFails(string varName, FileDB file)
        {
            //Arrange
            _filesRepository.UpdateFile(varName, file).Returns(false);
            var fileService = new FileService(_filesRepository);

            // Act
            var result = fileService.UpdateFile(varName, file);

            //Asert
            Assert.NotNull(result);
            Assert.IsType<bool>(result);
            Assert.Equal(false, result);

        }
    }
    }