using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp2.Models
{
    public class MailTrapSendMail
    {
        public string To { get; set; }
        public string to { get; internal set; }
        public string Header { get; set; }
        public string Body { get; set; }
    }
}
