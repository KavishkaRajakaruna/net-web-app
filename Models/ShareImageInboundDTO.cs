using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp2.Models
{
    public class ShareImageInboundDTO
    {
        public string ProviderId { get; set; }
        public string ImageId { get; set; }
        public DateTime SharedDate { get; set; }
        public DateTime ExpiereDate { get; set; }


    }
}
