using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.RabbitMQConsumer.Models
{
    public class SendMailModel
    {
        public List<string> To { get; set; }
        public string Message { get; set; }
    }
}
