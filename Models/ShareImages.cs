using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp2.Models
{
    public class ShareImages
    {
        public int Id { get; set; }
        public string ProviderId { get; set; }
        public int ImageId { get; set; }
        public DateTime? SharedDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool Expired { get; set; }

}
