using RabbitMQ.Client;
using RabbitMqDomain.Services;
using System.Text;
using System.Threading.Channels;

namespace RabbitMQPublisher.Services
{
    public class HeaderExchangePublisher : IDisposable 
    {
        private readonly RabbitMqService _rabbitMQService;
        private readonly IModel _rabbitMQchannel;
        private readonly IConnection _rabbitMQconection;
        private readonly string _exchangeName = "DemoHeaderExchange";

        private readonly string _queueOne = "queueOne";
        private readonly string _queueTwo = "queueTwo";
        private readonly string _queueThree = "queueThree";
        public HeaderExchangePublisher()
        {
            _rabbitMQService = new RabbitMqService();
            _rabbitMQconection = _rabbitMQService.GetRabbitMQConnection();

            _rabbitMQchannel = _rabbitMQconection.CreateModel();

            _rabbitMQchannel.ExchangeDeclare(_exchangeName, ExchangeType.Headers, false, false);

            _rabbitMQchannel.QueueDeclare(_queueOne, false, false, false);
            _rabbitMQchannel.QueueDeclare(_queueTwo, false, false, false);
            _rabbitMQchannel.QueueDeclare(_queueThree, false, false, false);


            var _dicOne = new Dictionary<string, object>() 
            {
                { "x-match", "all" },
                { "op", "export" },
                { "format", "pdf" }
            };
           _rabbitMQchannel.QueueBind(_queueOne, _exchangeName, string.Empty, _dicOne);

            var _dicTwo = new Dictionary<string, object>() 
            {
                {"x-match", "all"},
                {"op", "export"},
                {"format", "excell"}
            };
            _rabbitMQchannel.QueueBind(_queueTwo, _exchangeName, string.Empty, _dicTwo);

            var _dicThree = new Dictionary<string, object>() 
            {
                {"x-match", "any"},
                {"op", "export"},
                {"format", "zip"}
            };
            _rabbitMQchannel.QueueBind(_queueThree, _exchangeName, string.Empty, _dicThree);
        }


        public string PublishMessage()
        {

            var _props = _rabbitMQchannel.CreateBasicProperties();
            _props.Headers = new Dictionary<string, object>()
            {
                {"op", "export"},
                {"format", "pdf"}
            };
            _rabbitMQchannel.BasicPublish(_exchangeName, string.Empty, false, _props, Encoding.UTF8.GetBytes("PDF exported!"));

            _props = _rabbitMQchannel.CreateBasicProperties();
            _props.Headers = new Dictionary<string, object>
            {
                {"op", "export"},
                {"format", "excell"}
            };
            _rabbitMQchannel.BasicPublish(_exchangeName, string.Empty, _props, Encoding.UTF8.GetBytes("Excell exported!"));                     


            return "Message sent!";
        }

        public void Dispose()
        {
            _rabbitMQchannel?.Dispose();
            _rabbitMQconection?.Dispose();
        }

    }    
}