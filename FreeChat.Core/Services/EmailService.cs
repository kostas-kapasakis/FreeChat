using System;
using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Models;

namespace FreeChat.Core.Services
{

    public class EmailService : IEmailService
    {
        private const string AdminEmail = "kkkapasakis@yahoo.gr";

        public int EmailSender(EmailFormModel model)
        {

            try
            {
                //Configuring webMail class to send emails  
                //gmail smtp server  
//                WebMail.SmtpServer = "smtp.gmail.com";
//                //gmail port to send emails  
//                WebMail.SmtpPort = 587;
//                WebMail.SmtpUseDefaultCredentials = true;
//                //sending emails with secure protocol  
//                WebMail.EnableSsl = true;
//                //EmailId used to send emails from application  
//                WebMail.UserName = "kremusicman@gmail.com";
//                WebMail.Password = "aggelakas";
//
//                //Sender email address.  
//                WebMail.From = model.FromEmail;
//
//                //Send email  
//                WebMail.Send(to: model.ToEmail, subject: model.EmailSubject, body: model.Message, isBodyHtml: true);
                return 1;
            }
            catch (Exception)
            {
                return 0;

            }
            //            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            //            var message = new MailMessage();
            //            message.To.Add(new MailAddress(adminEmail));
            //            message.From = new MailAddress(model.FromEmail);
            //            message.Subject = "free Chat Contact";
            //            message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
            //            message.IsBodyHtml = true;
            //            try
            //            {
            //                using (var smtp = new SmtpClient())
            //                {
            //                    var credential = new NetworkCredential
            //                    {
            //                        UserName = adminEmail, // replace with valid value
            //                        Password = "trypes!@#$" // replace with valid value
            //                    };
            //                    smtp.Credentials = credential;
            //                    smtp.Host = "smtp-mail.outlook.com";
            //                    smtp.Port = 587;
            //                    smtp.EnableSsl = true;
            //                    await smtp.SendMailAsync(message);
            //
            //                    return 1;
            //                }
            //            }
            //            catch (Exception e)
            //            {
            //                Debug.Write(e.Message);
            //                return 0;
            //            }

        }


    }
}