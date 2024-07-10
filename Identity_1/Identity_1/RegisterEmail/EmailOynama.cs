using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net.Mail;
using System.Net;

namespace Identity_1.RegisterEmail
{
    public class EmailOynama : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mail = "";
            var pass = "";
            var mess = new MailMessage();
            mess.From = new MailAddress(mail);
            mess.Subject = subject;
            mess.To.Add(email);
            mess.Body = $"<html><Body>{htmlMessage}</Body></html>";
            mess.IsBodyHtml = true;

            var smt = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,

                Credentials = new NetworkCredential(mail, pass),

                EnableSsl = true


            };

            smt.Send(mess);
        }
    }
}
