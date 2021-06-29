using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp2.Models
{
    public class SendImageDetailsToProvider
    {
        public int ShareId { get; set; }
        public string UserId { get; set; }
        public string ImageName { get; set; }
        public string Type { get; set; }
        public string Level { get; set; }
        public string Url { get; set; }

    }
}
