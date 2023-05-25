using E_Commerce.RabbitMQProducer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.RabbitMQProducer.Interfaces
{
    public interface IMailProducer
    {
        void SendToMailQueue(SendMailModel model);
    }
}
