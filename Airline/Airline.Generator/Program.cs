using Airline.Generator;
using Airline.ServiceDefaults;
using Confluent.Kafka;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.Services.Configure<KafkaOptions>(builder.Configuration.GetSection("Kafka"));

var kafkaConnection = builder.Configuration.GetConnectionString("KafkaConnection");
if (string.IsNullOrWhiteSpace(kafkaConnection))
{
    throw new InvalidOperationException(
        "Connection string 'KafkaConnection' is missing in configuration.");
}

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