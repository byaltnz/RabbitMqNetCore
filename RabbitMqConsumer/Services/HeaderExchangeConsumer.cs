using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqDomain.Services;

namespace RabbitMQConsumer.Services
{
    public class HeaderExchangeConsumer
    {
        private readonly RabbitMqService _rabbitMQService;

        public HeaderExchangeConsumer(string _queueName)
        {
            _rabbitMQService = new RabbitMqService();

            using (var _connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var _channel = _connection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(_channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.Span;
                        var message = Encoding.UTF8.GetString(body);

                        Console.WriteLine("QueName:{0} Message: \"{1}\"", _queueName, message);
                       
                    };

                    _channel.BasicConsume(_queueName, true, consumer);
                   
                    Console.ReadLine();
                }
            }
        }
    }
}