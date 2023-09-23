using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqDomain.Services;

namespace RabbitMQConsumer.Services
{
    public class Consumer
    {
        private readonly RabbitMqService _rabbitMQService;

        public Consumer(string _queueName)
        {
            _rabbitMQService = new RabbitMqService();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var _channel = connection.CreateModel())
                {
                    var _consumer = new EventingBasicConsumer(_channel);
                    // Received event'i sürekli listen modunda olacaktır.
                    _consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.Span;
                        var message = Encoding.UTF8.GetString(body);

                        Console.WriteLine("Queue:{0}, Received Message: \"{1}\"", _queueName, message);
                        //_channel.BasicAck(ea.DeliveryTag, false); // Explicit act.
                    };

                    _channel.BasicConsume(_queueName, true, _consumer); // Implicit  act.
                    Console.ReadLine();
                }
            }
        }
    }
}