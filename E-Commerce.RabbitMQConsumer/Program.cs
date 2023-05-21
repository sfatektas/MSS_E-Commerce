// See https://aka.ms/new-console-template for more information

using E_Commerce.RabbitMQConsumer;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: false);

IConfiguration config = builder.Build();


var consumer = new MailConsumer(config);

await consumer.ReadMessageFromQueue();