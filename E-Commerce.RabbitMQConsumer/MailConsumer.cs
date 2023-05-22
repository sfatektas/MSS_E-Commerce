using E_Commerce.RabbitMQConsumer.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.RabbitMQConsumer
{
    public class MailConsumer
    {
        protected ConnectionFactory factory = new ConnectionFactory();
        protected IConnection connection;
        protected IModel channel;
        protected EventingBasicConsumer consumer;
        readonly IMailService _mailService;
        public MailConsumer(IConfiguration config)
        {
            factory.Uri = new("amqps://xamohava:spM7OwkS3NfNFbE9e8K5naFn_UW3fPWq@shrimp.rmq.cloudamqp.com/xamohava");
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "sendmail-queue", durable: true, exclusive: false );
            consumer = new(channel);

            //mail Service configuration 
            _mailService = new MailService(config["MailSettings:FromTo"], config["MailSettings:FromPassword"]);
        }
        public async Task ReadMessageFromQueue()
        {
            channel.BasicConsume(queue: "sendmail-queue", autoAck: true, consumer: consumer); // Mesajlar otomatik silinir.
            consumer.Received += async (sender, e) =>
            {
                var message = e.Body.Span.ToArray();
                var mailModel = JsonConvert.DeserializeObject<SendMailModel>(Encoding.UTF8.GetString(message));
                await _mailService.SendMessage(mailModel);

                Console.WriteLine($"{Encoding.UTF8.GetString(message)}");
            };
            Console.Read();
        }
    }
}
