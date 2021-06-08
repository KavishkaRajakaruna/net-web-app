using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapp2.Models
{
    public class S3FileUpload
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        [Display(Name="File")]
        public IFormFile FormFile { get; set; }
    }
}
