
using RabbitMQConsumer.Services;


Console.Write("Queue Name:");
string _queName = Console.ReadLine();

Console.Title = "Consumer:" + _queName;

Console.WriteLine(_queName + " waiting...");

#region Consumers
var _consumer = new Consumer(_queName);
//var _consumer = new DirectExchangeConsumer(_queName);
//var _consumer = new FanoutExchangeConsumer(_queName);
//var _consumer = new TopicExchangeConsumer(_queName);
//var _consumer = new HeaderExchangeConsumer(_queName);
//var _dataConsumer = new ConsumerData(_queName);
#endregion