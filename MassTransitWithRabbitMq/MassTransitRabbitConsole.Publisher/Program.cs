using MassTransit;
using MassTransitRabbit.Shared;
using MassTransitRabbit.Shared.Messages;

// string rabbitMqUri = enter the rabbitmq uri
string queueName = "example";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory => factory.Host(rabbitMqUri));

var sendEndPoint = await bus.GetSendEndpoint(new($"{rabbitMqUri}/{queueName}"));  // send message to specific queue
Console.WriteLine("Gonderilecek mesaj:  ");

string message = Console.ReadLine();
await sendEndPoint.Send<IMessage>(new ExampleMessage() 
{
    Text = message
});

Console.ReadLine();