var builder = DistributedApplication.CreateBuilder(args);

var kafkaTopic = builder.AddParameter("KafkaTopic", "ticket-events");
var producerIntervalMs = builder.AddParameter("KafkaProducerIntervalMs", "3000");
var producerBatchSize = builder.AddParameter("KafkaProducerBatchSize", "2");
var consumerGroup = builder.AddParameter("KafkaConsumerGroup", "airline-api-consumer");

var mssql = builder.AddMySql("MySql");
var mssqlDb = mssql.AddDatabase("AirlineDb");

var kafka = builder.AddKafka("Kafka")
       .WithKafkaUI();

builder.AddProject<Projects.Airline_Api>("AirlineAppAPI")
       .WithReference(mssqlDb, "DefaultConnection")
       .WithReference(kafka, "KafkaConnection")
       .WithEnvironment("KafkaTopic", kafkaTopic)
       .WithEnvironment("Kafka_ConsumerGroup", consumerGroup)
       .WaitFor(mssqlDb)
       .WaitFor(kafka);


builder.AddProject<Projects.Airline_Generator>("AirlineGenerator")
       .WithReference(kafka, "KafkaConnection")
       .WithEnvironment("KafkaTopic", kafkaTopic)
       .WithEnvironment("KafkaProducerIntervalMs", producerIntervalMs)
       .WithEnvironment("KafkaProducerBatchSize", producerBatchSize)
       .WaitFor(kafka);

builder.Build().Run();