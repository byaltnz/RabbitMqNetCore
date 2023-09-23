using RabbitMQ.Client;
using RabbitMqDomain.Services;
using System;
using System.Text;
using System.Threading.Channels;

namespace RabbitMQPublisher.Services
{
    public class DirectExchangePublisher : IDisposable 
    {
        private readonly RabbitMqService _rabbitMQService;
        private readonly IModel _rabbitMQchannel;
        private readonly IConnection _rabbitMQconection;
        private readonly string _exchangeName = "DemoDirectExChange";

        private readonly string _queueOne = "queueOne";
        private readonly string _queueTwo = "queueTwo";
        private readonly string _queueThree = "queueThree";

        public DirectExchangePublisher()
        {
            _rabbitMQService = new RabbitMqService();
            _rabbitMQconection = _rabbitMQService.GetRabbitMQConnection();

            _rabbitMQchannel = _rabbitMQconection.CreateModel();

            _rabbitMQchannel.ExchangeDeclare(_exchangeName, ExchangeType.Direct, false, false);

            _rabbitMQchannel.QueueDeclare(_queueOne, false, false, false);           
            _rabbitMQchannel.QueueDeclare(_queueTwo, false, false, false);
            _rabbitMQchannel.QueueDeclare(_queueThree, false, false, false);


            _rabbitMQchannel.QueueBind(_queueOne, _exchangeName, "log.error");
            _rabbitMQchannel.QueueBind(_queueTwo, _exchangeName, "log.warning");
            _rabbitMQchannel.QueueBind(_queueThree, _exchangeName, "log.info");
        }


        public string PublishMessage(string _routing_key, string message)
        {        
            //System.Threading.Thread.Sleep(300);
            _rabbitMQchannel.BasicPublish(_exchangeName, _routing_key, null, Encoding.UTF8.GetBytes(message));

           return $"ExchangeName:{_exchangeName}, RoutingKey:{_routing_key}, Message:{message}";
        }

        public void Dispose()
        {
            _rabbitMQchannel?.Dispose();
            _rabbitMQconection?.Dispose();
        }

    }    
}