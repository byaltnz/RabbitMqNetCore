using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqDomain.Services;

namespace RabbitMQConsumer.Services
{
    public class TopicExchangeConsumer
    {
        private readonly RabbitMqService _rabbitMQService;

        public TopicExchangeConsumer(string _queueName)
        {
            _rabbitMQService = new RabbitMqService();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.Span;
                        var message = Encoding.UTF8.GetString(body);

                        Console.WriteLine("QueName:{0} Message: \"{1}\"", _queueName, message);
                       
                    };

                    channel.BasicConsume(_queueName, true, consumer);
                   
                    Console.ReadLine();
                }
            }
        }
    }
}