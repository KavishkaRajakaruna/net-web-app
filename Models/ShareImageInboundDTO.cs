using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp2.Models
{
    public class ShareImageInboundDTO
    {
        public string ProviderId { get; set; }
        public int ImageId { get; set; }
        public DateTime SharedDate { get; set; }
        public int ExpirePeriod { get; set; }


    }
}
