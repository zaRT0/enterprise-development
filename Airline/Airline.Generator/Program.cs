using Airline.Generator;
using Airline.ServiceDefaults;
using Confluent.Kafka;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

var kafkaConnection = builder.Configuration["ConnectionStrings:KafkaConnection"] ?? "localhost:9092";

builder.Services.AddSingleton(s =>
{
    var config = new ProducerConfig
    {
        BootstrapServers = kafkaConnection,
        Acks = Acks.All,
        EnableIdempotence = true
    };
    return new ProducerBuilder<Null, string>(config).Build();
});

builder.Services.AddHostedService<KafkaProducer>();

var host = builder.Build();
host.Run();