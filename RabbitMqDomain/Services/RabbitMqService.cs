using RabbitMQ.Client;

namespace RabbitMqDomain.Services
{
    public class RabbitMqService
    {
        // localhost rabbitmq adress
        private readonly string _hostName = "localhost";

        public IConnection GetRabbitMQConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                //definitins for default rabbitmq connection user (guest).You can change your own server information.
                HostName = _hostName                
                
            };

            return connectionFactory.CreateConnection();
        }
    }
}