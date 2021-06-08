using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp2.Models
{
    public class SlackPayload
    {
        [JsonProperty("Channel")]
        public string Channel { get; set; }
        [JsonProperty("Text")]
        public string Text { get; set; }
    }
}
