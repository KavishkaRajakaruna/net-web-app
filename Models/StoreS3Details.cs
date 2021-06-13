using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp2.Models
{
    public class StoreS3Detail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Level { get; set; }
        public string Url { get; set; }
        public bool Deleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
