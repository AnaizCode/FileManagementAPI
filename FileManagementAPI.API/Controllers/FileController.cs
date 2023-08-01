using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using File.Services.Services.Interfaces;
using File.Database;
using File.API.Utils;

namespace File.Services.Controllers
{
    [ApiController]
    public class FileController : ControllerBase
    {
        private IFileService _IFileService;
        public FileController(IFileService FileService)
        {
            _IFileService = FileService;

        }

        [HttpPost]
        [Route("api/file/")]
        public IActionResult  SaveFileDataBase( IFormFile file) {

            bool v = _IFileService.SaveFile(file);
            return Ok(v); 
        }

        [HttpGet]
        [Route("api/file/name/{varName}")]
        public IActionResult GetFileFromDatabase([FromRoute]string varName)
        {
            FileDB dbFile = _IFileService.GetFile(varName);
            string textString = dbFile.BinaryFile;
            byte[] fileBytes = UtilsConverter.ConvertFrom64StringToBytes(textString);

            string contentType = "application/pdf";

            string fileName = dbFile.FileName;

           return File(fileBytes, contentType, fileName);
        }

        [HttpDelete]
        [Route("api/file/name/{varName}")]
        public IActionResult DeleteFileDatabase([FromRoute] string varName)
        {

            bool Results = _IFileService.DeleteFile(varName);
            if (Results == true) { return Ok(Results); }
            else { return BadRequest(); }
        }

        [HttpPut]
        [Route("api/file/name/{varName}/{newName}")]
        public IActionResult UpdateFileNameDatabase([FromRoute] string varName, [FromRoute] string newName)
        {

            bool Results = _IFileService.UpdateFile(varName, newName);
            if (Results == true) { return Ok(Results); }
            else { return BadRequest(); }
        }

        [HttpPut]
        [Route("api/file/file/{varName}")]
        public IActionResult UpdateFileContentDatabase([FromRoute] string varName, IFormFile varFile)
        {

            bool Results = _IFileService.UpdateFile(varName,varFile);
            if (Results == true) { return Ok(Results); }
            else { return BadRequest(); }
        }


        [HttpPut]
        [Route("api/file/name/file/{varName}/{newName}")]
        public IActionResult UpdateFileContentAndNameDatabase([FromRoute] string varName, [FromRoute] string newName, IFormFile varFile)
        {

            bool Results = false;
            bool fileResult = _IFileService.UpdateFile(varName, varFile);
            bool fileName = _IFileService.UpdateFile(varName, newName);
            if (fileResult == true && fileName == true) { Results = true; }
            if (Results == true) { return Ok(Results); }
            else { return BadRequest(); }
        }
    }
}
