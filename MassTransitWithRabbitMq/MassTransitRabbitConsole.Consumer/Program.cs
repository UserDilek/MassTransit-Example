using MassTransit;
using MassTransitRabbit.Shared;
using MassTransitRabbit.Shared.Messages;
using MassTransitRabbitConsole.Consumer.Consumers;

//string rabbitMqUri = enter the rabbitmq uri
string queueName = "example";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory => {
    factory.Host(rabbitMqUri);
    factory.ReceiveEndpoint(queueName, endpoint =>
    {
        endpoint.Consumer<ExampleMessageConsumer>();
    });
    });


await bus.StartAsync();

Console.ReadLine();