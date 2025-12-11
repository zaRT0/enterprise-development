namespace Airline.Api.Kafka;

/// <summary>
/// Configuration options for the Kafka consumer in the API service.
/// Specifies the Kafka topic to subscribe to and the consumer group ID used for offset management and message distribution.
/// </summary>
public class KafkaOptions
{
    /// <summary>
    /// Gets or sets the name of the Kafka topic from which the consumer will read messages.
    /// Default value is "ticket-events".
    /// </summary>
    public string Topic { get; set; } = "ticket-events";

    /// <summary>
    /// Gets or sets the consumer group ID used for offset tracking and workload distribution among consumers.
    /// Default value is "airline-api-ticket-consumer".
    /// </summary>
    public string ConsumerGroup { get; set; } = "airline-api-ticket-consumer";
}
