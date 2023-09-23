# .Net 7 C# code for RabbitMQ

Here you can find the C# code examples for RabbitMQ using .NET 7.0

You will also find a solution file for Visual Studio 2022.

To successfully use the examples you will need a running RabbitMQ server.

## Requirements

### Requirements on Windows

* [dotnet core (.Net 7)](https://www.microsoft.com/net/core)
* [RabbitMQ Client](https://www.nuget.org/packages/RabbitMQ.Client)

We're using Visual Studio compile and run the code. After compile, you can create some instances of "Publisher" and "Consumer" console applications which is in build folder.

### Requirements on Linux

* [dotnet core](https://www.microsoft.com/net/core)

### Code

Each command is best run in a separate console instance run from the root of the tutorial directory. You can find examples for all exchange types of rabbitmq in this example.To run the examples please follow the direction below.  

### [Tutorial one: "Default Exchange"]

	RabbitMQPublisher > Program.cs => Uncomment "Publisher" region and comment out all other code regions.
	RabbitMQConsumer > Program.cs => Uncomment "Consumer" service code line, comment out all other code lines in "Consumers" region.

### [Tutorial two: Direct Exchange]

	RabbitMQPublisher > Program.cs => Uncomment "DirectExchange" region and comment out all other code regions.
	RabbitMQConsumer > Program.cs => Uncomment "DirectExchangeConsumer" service code line, comment out all other code lines in "Consumers" region.

### [Tutorial three: Fanout Exchange]

	RabbitMQPublisher > Program.cs => Uncomment "FanoutExchange" region and comment out all other code regions.
	RabbitMQConsumer > Program.cs => Uncomment "FanoutExchangeConsumer" service code line, comment out all other code lines in "Consumers" region.

### [Tutorial three: Topic Exchange]

	RabbitMQPublisher > Program.cs => Uncomment "TopicExchange" region and comment out all other code regions.
	RabbitMQConsumer > Program.cs => Uncomment "TopicExchangeConsumer" service code line, comment out all other code lines in "Consumers" region.

### [Tutorial four: Header Exchange]

	RabbitMQPublisher > Program.cs => Uncomment "HeaderExchange" region and comment out all other code regions.
	RabbitMQConsumer > Program.cs => Uncomment "HeaderExchangeConsumer" service code line, comment out all other code lines in "Consumers" region.

### [Tutorial five: JSON Data Example]

	RabbitMQPublisher > Program.cs => Uncomment "DataPublish" region and comment out all other code regions.
	RabbitMQConsumer > Program.cs => Uncomment "ConsumerData" service code line, comment out all other code lines in "Consumers" region.
	
	In this example you can use "dummy_users.json" file as a datasource, which is included in solution. 
		
### [Tutorial six: Message Loop Example]

	RabbitMQPublisher > Program.cs => Uncomment "PublisherLoop" region and comment out all other code regions.
	RabbitMQConsumer > Program.cs => Uncomment "Consumer" service code line, comment out all other code lines in "Consumers" region.
	
	In this example, the speed and performance of one and more consumers can be compared.   
	You can adjust the message rate by changing the value in the line containing the code "System.Threading.Thread.Sleep(100);"