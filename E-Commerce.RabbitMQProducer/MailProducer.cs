using E_Commerce.RabbitMQProducer.Interfaces;
using E_Commerce.RabbitMQProducer.Models;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;

namespace E_Commerce.RabbitMQPublisher
{
    public class MailProducer : IMailProducer
    {
        readonly IConnection _connection;
        readonly IModel _channel;
        public MailProducer()
        {
            //Bağlantı Oluşturm işlemi 
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new("amqps://xamohava:spM7OwkS3NfNFbE9e8K5naFn_UW3fPWq@shrimp.rmq.cloudamqp.com/xamohava");
            //Bağlantıyı Aktşfleştirme ve channel açma 
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            //Queue oluşturma 
            _channel.QueueDeclare("sendmail-queue", exclusive: false,durable:true);
        }

        public void SendToMailQueue(SendMailModel model)
        {
            byte[] body = Encoding.UTF8.GetBytes(model.ToString());
            _channel.BasicPublish(exchange: "", routingKey: "sendmail-queue", body: body);
        }
    }
}