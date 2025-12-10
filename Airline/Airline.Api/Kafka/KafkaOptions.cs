namespace Airline.Api.Kafka;

/// <summary>
/// Configuration options for the Kafka consumer in the API service.
/// Specifies the Kafka topic to subscribe to and the consumer group ID used for offset management and message distribution.
/// </summary>
public class KafkaOptions
{
    public string Topic { get; set; } = "ticket-events";

    public string ConsumerGroup { get; set; } = "airline-api-ticket-consumer";
}
