using RabbitMQ.Client;
using RabbitMqDomain.Services;
using System.Text;

namespace RabbitMQPublisher.Services
{
    public class FanoutExchangePublisher : IDisposable 
    {
        private readonly RabbitMqService _rabbitMQService;
        private readonly IModel _rabbitMQchannel;
        private readonly IConnection _rabbitMQconection;
        private readonly string _exchangeName = "DemoFanoutExChange";

        private readonly string _queueOne = "queueOne";
        private readonly string _queueTwo = "queueTwo";
        private readonly string _queueThree = "queueThree";
        public FanoutExchangePublisher()
        {
            _rabbitMQService = new RabbitMqService();
            _rabbitMQconection = _rabbitMQService.GetRabbitMQConnection();

            _rabbitMQchannel = _rabbitMQconection.CreateModel();

            _rabbitMQchannel.ExchangeDeclare(_exchangeName, ExchangeType.Fanout, false, false);

            _rabbitMQchannel.QueueDeclare(_queueOne, false, false, false);
            _rabbitMQchannel.QueueDeclare(_queueTwo, false, false, false);
            _rabbitMQchannel.QueueDeclare(_queueThree, false, false, false);


            _rabbitMQchannel.QueueBind(_queueOne, _exchangeName, string.Empty); // Fanoout exchange not care for routing key
            _rabbitMQchannel.QueueBind(_queueTwo, _exchangeName, string.Empty);
            _rabbitMQchannel.QueueBind(_queueThree, _exchangeName, string.Empty);

        }


        public string PublishMessage(string message)
        {      

            _rabbitMQchannel.BasicPublish(_exchangeName, string.Empty, null, Encoding.UTF8.GetBytes(message));

            return $"ExchangeName:{_exchangeName}, Message:{message}";
        }

        public void Dispose()
        {
            _rabbitMQchannel?.Dispose();
            _rabbitMQconection?.Dispose();
        }

    }    
}