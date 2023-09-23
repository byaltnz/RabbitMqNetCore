using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqDomain.Models;
using RabbitMqDomain.Services;
using System.Text;
using System.Text.Json;

namespace RabbitMQConsumer.Services
{
    public class ConsumerData
    {
        private readonly RabbitMqService _rabbitMQService;

        public ConsumerData(string queueName)
        {
            _rabbitMQService = new RabbitMqService();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var _channel = connection.CreateModel())
                {
                    var _consumer = new EventingBasicConsumer(_channel);
                    // Received event listener
                    _consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.Span;
                        var message = Encoding.UTF8.GetString(body);
                       
                        var _user = JsonSerializer.Deserialize<User>(message);
                        if (_user != null) {
                            
                            Console.WriteLine("{0}-{1}-{2} mail sent!", _user.id, _user.name,_user.email);
                        }
                       
                        #region Custom Ack
                        /* 
                         if (_user.id < 20)
                             _channel.BasicNack(ea.DeliveryTag, false,false);
                         else
                             _channel.BasicAck(ea.DeliveryTag, false);
                        */

                        _channel.BasicAck(ea.DeliveryTag, false);
                        #endregion
                    };

                    _channel.BasicConsume(queueName, false, _consumer);

                    Console.ReadLine();
                }
            }
        }
    }
}