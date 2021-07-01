using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp2.Models
{
    public class ShareImage
    {
        public int Id { get; set; }
        public string ProviderId { get; set; }
        public int ImageId { get; set; }
        public DateTime? SharedDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool Expired { get; set; }
        public string UserId { get; set; }

        public StoreS3Detail storeS3Detail { get; set; }
    }
}
