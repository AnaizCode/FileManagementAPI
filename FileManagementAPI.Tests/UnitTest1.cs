using File.Services.Services.Interfaces;
using File.Services.Services.Implementation;
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
using File.Database.Repository.Interface;
using File.Database;
using AutoFixture.Xunit2;
using File.Services.Models;
using File.Services.Converter.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace File.Tests
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        private IFileService _FileService;
        private IFormFile _file;
        private IFilesRepository _filesRepository;
        private IFileConverters _converters;
        public UnitTest1()
        {
            this._FileService = Substitute.For<IFileService>();
            
            this._filesRepository = Substitute.For<IFilesRepository>();
            this._converters = Substitute.For<IFileConverters>();
        }
        [Theory, AutoData]
        public void WhenFileServiceReturnsRightString(FileDB file)
        {

            //Arrange
           var FileRequest = new RequestSaveFileModel() ;

            _filesRepository.AddFile(file).Returns(true);
            _converters.convertToModelSaveFile(FileRequest).Returns(file);


            var FileService = new FileService(_filesRepository, _converters);
            var _file = GetFormFile("Test44");


            // Act
            var result = FileService.SaveFile(_file);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<bool>(result);
            Assert.Equal(true, result);

        }

        public IFormFile GetFormFile(string str)
        {
            //Setup mock file using a memory stream
            var content = str;
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
            return file;
        }

        //[Theory]
        //[InlineData("nombreArchivo")]
        //public void WhenFileServiceGetFileWorks(string Filename) {
        //    //arrange
        //    var file = new FileDB();
        //    _filesRepository.GetFile(Filename).Returns(file);

        //    var fileService = new FileService(_filesRepository);

        //    //act
        //    var result =  fileService.GetFile(Filename);

        //    //assert
        //    Assert.NotNull(result);
        //    Assert.IsType<FileDB>(result);
        //    Assert.Equal(file, result);

        //}

        [Theory]
        [InlineData("file2.txt")]
        public void WhenFilesRepositoryGetFileWorks(string Filename)
        {
           var files = new List<FileDB>
{
    new FileDB { FileName = "file1.txt" },
    new FileDB { FileName = "file2.txt" },
    new FileDB { FileName = "file2.txt" },
    new FileDB { FileName = "file2.txt" },
    new FileDB { FileName = "file2.txt" },
    new FileDB { FileName = "file2.txt" },
}.AsQueryable();

var mockDbSet = new Mock<DbSet<FileDB>>();
            var context = new Mock<DBFileContext>();
            context.Setup(c => c.Files).Returns(mockDbSet.Object);


            //act
            var result = _filesRepository.GetFile(Filename);

            //assert
        }
    }
    
    }