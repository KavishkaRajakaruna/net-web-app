using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Text;
using webapp2.Models;
using Microsoft.AspNetCore.Mvc;

namespace webapp2.Helpers
{
    public class MailTrapEmailGenerator
    {
     
        public async Task<IActionResult> MailGenerator(MailTrapSendMail model)
        {
            MailAddress to = new MailAddress(model.To);
            MailAddress from = new MailAddress("info@belcalies.com");

            MailMessage message = new MailMessage(from, to);
            message.Subject = model.Header;
            message.Body = model.Body;
        }

        SmtpClient client = new SmtpClient("smtp.mailtrap.io", 2525)
        {
            Credentials = new NetworkCredential("b87f9e1fb4f16f", "90af90006f4e9f"),
            EnableSsl = true
        };
          
    }
}
