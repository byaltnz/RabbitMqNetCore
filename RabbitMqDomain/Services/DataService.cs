using RabbitMqDomain.Models;
using System.Text.Json;

namespace RabbitMQPublisher.Services
{
    public class DataService
    {
        public DataService()
        {
                
        }

        public List<User> LoadJson()
        {
            using (StreamReader r = new StreamReader("D:\\dummy_users.json"))
            {
                string json = r.ReadToEnd();
                List<User> _users = JsonSerializer.Deserialize<List<User>>(json);

                return _users;
            }            
        }
    }
}
