using RabbitMQPublisher.Services;

Console.Title = "Publisher";


#region Publisher

while (true)
{
    Console.Write("Routing Key:");
    string _routingKey = Console.ReadLine();

    Console.Write("Message:");
    string _message = Console.ReadLine();

    using (var _publisher = new Publisher(_routingKey))
    {
        var _res = _publisher.PublishMessage(_routingKey, _message);

        Console.WriteLine(_res);
        Console.WriteLine("Publish Ok");
        Console.ReadLine();
    }
}

#endregion

#region PublisherLoop

/*Console.Write("Routing Key:");
string _routingKey = Console.ReadLine();

using (var _publisher = new Publisher(_routingKey))
{
    for (int i = 0; i < 10000; i++)
    {
        System.Threading.Thread.Sleep(100);
        var _res = _publisher.PublishMessage(_routingKey, DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.fff"));
        Console.WriteLine(_res);
    }
}*/
#endregion

#region DataPublish
/*Console.Write("Routing Key:");

string _queName = Console.ReadLine();

using (var _dataPublisher = new PublisherData(_queName))
{ 
    var _userData = new DataService().LoadJson().Where(x => x.id < 50000);

    foreach (var item in _userData)
    {
        System.Threading.Thread.Sleep(1000);

        var _objJson = JsonSerializer.Serialize<User>(item);

        var _res = _dataPublisher.PublishMessage(_queName, _objJson);
        Console.WriteLine(_res.ToString());
    }
}*/
#endregion

#region DirectExchange 
/*using (var _publisher = new DirectExchangePublisher())
{
    while (true)
    {
        Console.Write("Routing Key:");

        string _routingKey = Console.ReadLine();
        Console.Write("Message:");

        string _message = Console.ReadLine();

        var _res = _publisher.PublishMessage(_routingKey, _message);

        Console.WriteLine(_res.ToString());
        Console.WriteLine("Publish Ok");
        Console.ReadLine();
    }
}*/
#endregion

#region FanoutExchange 
/*using (var _publisher = new FanoutExchangePublisher())
{
    //Fanoutexchange'de Routing key yok

    while (true)
    {       
        Console.Write("Message:");
        string _message = Console.ReadLine();

        var _res = _publisher.PublishMessage(_message);

        Console.WriteLine(_res.ToString());
        Console.WriteLine("Publish Ok");
        Console.ReadLine();
    }
}*/
#endregion

#region TopicExchange 
/*using (var _publisher = new TopicExchangePublisher())
{
    while (true)
    {
        Console.Write("Routing Key:");
        string _routingKey = Console.ReadLine();
        
        Console.Write("Message:");
        string _message = Console.ReadLine();

        var _res = _publisher.PublishMessage(_routingKey, _message);

        Console.WriteLine(_res.ToString());
        Console.WriteLine("Publish Ok");
        Console.ReadLine();
    }
}*/
#endregion

#region HeaderExchange 
/*using (var _publisher = new HeaderExchangePublisher())
{
    while (true)
    {
        var _res = _publisher.PublishMessage();

        Console.WriteLine(_res.ToString());
        Console.WriteLine("Publish Ok");
        Console.ReadLine();
    }
}*/
#endregion