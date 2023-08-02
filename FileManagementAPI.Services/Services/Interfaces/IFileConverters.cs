using FileManagementAPI.Services.Models;
using FileManagementAPI.Database;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementAPI.Services.Services.Interfaces
{
    public interface IFileConverters
    {
        FileDB convertToModelSaveFile(RequestSaveFileModel requestSaveFileModel);
    }
}
