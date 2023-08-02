﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FileManagementAPI.Services.Models
{
    public class RequestSaveFileModel
    {
        [Key]
        public int FileId { get; set; }
        public string FileName { get; set; }
        public IFormFile File { get; set; }

    }
}
