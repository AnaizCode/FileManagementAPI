using File.Database;
using File.Services.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File.Services.Converter.Interfaces
{
    public interface IFileConverters
    {
        FileDB convertToModelSaveFile(RequestSaveFileModel requestSaveFileModel);
    }
}
