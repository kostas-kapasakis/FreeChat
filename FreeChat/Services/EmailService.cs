using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using FreeChat.Models;
using FreeChat.Services.ServicesInterfaces;

namespace FreeChat.Services
{

    public class EmailService : IEmailService
    {
        private const string adminEmail = "kkkapasakis@yahoo.gr";

        public async Task<int> EmailSender(EmailFormModel model)
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(adminEmail));
            message.From = new MailAddress(model.FromEmail);
            message.Subject = "free Chat Contact";
            message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
            message.IsBodyHtml = true;
            try
            {
                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = adminEmail, // replace with valid value
                        Password = "trypes!@#$" // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);

                    return 1;
                }
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return 0;
            }

        }
    }
}