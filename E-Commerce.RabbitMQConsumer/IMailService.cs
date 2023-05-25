using E_Commerce.RabbitMQConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.RabbitMQConsumer
{
    public interface IMailService
    {
         Task SendMessage(SendMailModel model, string subject = "Bilgilendirme");
    }
}
