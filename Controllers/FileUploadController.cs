using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using webapp2.Authentication;
using webapp2.Helpers;
using webapp2.Models;

namespace webapp2.Controllers
{
    [Route("api/")]
    [ApiController]
    
    public class FileUploadController : ControllerBase
    {
        [HttpPost]
        [Route("file/uploader")]
        public async Task<IActionResult> FileUpload(S3FileUpload fileUpload)
        {
            using(var memoryStream = new MemoryStream())
            {
                await fileUpload.FormFile.CopyToAsync(memoryStream);

                if (memoryStream.Length < 2097152)
                {
                    await S3Upload.UploadFileAsync(memoryStream, "Bucket_Name", "Key_Name");
                    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "File Upload success" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Upload failed" });

                }
            }
        }
    }
}
