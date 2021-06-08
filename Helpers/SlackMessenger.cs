using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using webapp2.Models;

namespace webapp2.Helpers
{
    public class SlackMessenger
    {
        private readonly Uri  _uri;
        private readonly Encoding _encoding = new UTF8Encoding ();
        
        private void PostMessage (SlackMessage model)
        {
            var payload = new SlackPayload
            {
                Channel = "system-dev",
                Text = model.ToString(),
            };

            var payloadjson = JsonConvert.SerializeObject(payload);
            using (var client = new WebClient())
            {
                var data = new NameValueCollection { ["payload"] = payloadjson };
                var response = client.UploadValues(_uri, "POST", data);
                //return _encoding.GetString(response);
            }
        }
    }
}
