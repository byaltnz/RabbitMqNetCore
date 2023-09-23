using RabbitMQ.Client;
using RabbitMqDomain.Services;
using System;
using System.Text;
using System.Threading.Channels;

namespace RabbitMQPublisher.Services
{
    public class Publisher : IDisposable
    {
        private readonly RabbitMqService _rabbitMQService;
        private readonly IModel _rabbitMQchannel;
        private readonly IConnection _rabbitMQconection;
        public Publisher(string _routingKey)
        {
            _rabbitMQService = new RabbitMqService();
            _rabbitMQconection = _rabbitMQService.GetRabbitMQConnection();
            _rabbitMQchannel = _rabbitMQconection.CreateModel();            

            _rabbitMQchannel.QueueDeclare(_routingKey, false, false, false);
        }
        public string PublishMessage(string _routingKey, string _message)
        {

            #region Persistence Message example
            /*
                var props = _rabbitMQchannel.CreateBasicProperties();
                props.Persistent = true; // or props.DeliveryMode = 2;
            */
            #endregion           

            //default exchange.
            _rabbitMQchannel.BasicPublish("", _routingKey, null, Encoding.UTF8.GetBytes(_message));

            return $"Queue:{_routingKey}, Outgoing message:{_message}";
        }

        public void Dispose()
        {
            _rabbitMQchannel?.Dispose();
            _rabbitMQconection?.Dispose();
        }

    }
}