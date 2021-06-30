using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public void Post([FromBody] Models.ShareImageInboundDTO ShareInfo)
        {

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
