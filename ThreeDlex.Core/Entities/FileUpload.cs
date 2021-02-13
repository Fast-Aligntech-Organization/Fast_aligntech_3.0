using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDlex.Core.Entities
{
    public class FileUpload
    {
        public int Id { get; set; }
        public IFormFile File { get; set;}
        public string Entity { get; set; }

    }
}
