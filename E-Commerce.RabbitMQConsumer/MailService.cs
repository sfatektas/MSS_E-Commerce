using E_Commerce.RabbitMQConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.RabbitMQConsumer
{
    public class MailService : IMailService
    {
        private readonly string FromMail;
        private readonly string FromPassword;

        public MailService(string fromMail , string fromPassword)
        {
            FromMail = fromMail;
            FromPassword = fromPassword;
        }
        
        public async Task SendMessage(SendMailModel model, string subject = "Bilgilendirme")
        {
            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(FromMail);
                model.To.ForEach((to) => message.To.Add(to));
                message.Subject = subject;
                message.Body = model.Message;
                message.IsBodyHtml = false;

                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(FromMail, FromPassword),
                    EnableSsl = true
                };
                await client.SendMailAsync(message);
            }
        }
    }
}
