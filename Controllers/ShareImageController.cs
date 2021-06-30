using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareImageController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ShareImageController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/<ShareImageController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ShareImageController>/CompanyId
        [HttpGet("{UserId}")]
        public string Get(int id)
        {
           
            return "value";
        }

        // POST api/<ShareImageController>
        [HttpPost]
        public void Post([FromBody] ShareImageInboundDTO ShareInfo)
        {
            var user = HttpContext.User.Identity;
            using (var context = new AbsoluteDbContext())
            {
                var image = new ShareImage()
                {
                    ProviderId = ShareInfo.ProviderId,
                    ImageId = ShareInfo.ImageId,
                    SharedDate = DateTime.Now,
                    ExpireDate = DateTime.Now.AddDays(ShareInfo.ExpirePeriod),
                    UserId = User.Identity.ToString()
                };

                context.ShareImages.Add(image);
                context.SaveChanges();
            }
        }

        // PUT api/<ShareImageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShareImageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
