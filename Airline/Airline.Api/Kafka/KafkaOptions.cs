namespace Airline.Api.Kafka;

public class KafkaOptions
{
    public string Topic { get; set; } = "ticket-events";
    public string ConsumerGroup { get; set; } = "airline-api-ticket-consumer";
}
