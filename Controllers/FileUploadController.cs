﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        
        
        [HttpPost]
        [Route("file/uploader")]
        public async Task<IActionResult> FileUpload(S3FileUpload fileUpload)
        {
            using(var memoryStream = new MemoryStream())
            {
                await fileUpload.FormFile.CopyToAsync(memoryStream);
                StoreS3Details detials = new StoreS3Details
                {
                    Name = fileUpload.Name,
                    Type = fileUpload.Type,
                    Level = fileUpload.Level
                };

                //get current login user
                ApplicationUser user = await GetCurrentUserAsync();
                Guid obj = Guid.NewGuid();
                string ObjectName = obj.ToString();
                ObjectName = ObjectName.Substring(ObjectName.Length - 16);
                string folderPathWithName = (user.Id + "/" + ObjectName).ToString();


                if (memoryStream.Length < 2097152)
                {
                    await S3Upload.UploadFileAsync(memoryStream, "Bucket_Name", folderPathWithName);

                    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "File Upload success" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Upload failed" });

                }
            }
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
