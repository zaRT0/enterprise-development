namespace Airline.Generator;

/// <summary>
/// Configuration options for the Kafka producer used in the ticket generation service.
/// Contains settings such as topic name, message batch size, and production interval.
/// </summary>
public class KafkaOptions
{
    /// <summary>
    /// Kafka topic name for sending ticket event messages.
    /// Default: "ticket-events".
    /// </summary>
    public string Topic { get; set; } = "ticket-events";

    /// <summary>
    /// Interval (in milliseconds) between sending message batches.
    /// Default: 5000 (5 seconds).
    /// </summary>
    public int ProducerIntervalMs { get; set; } = 5000;

    /// <summary>
    /// Number of messages sent per iteration (batch size).
    /// Default: 1.
    /// </summary>
    public int ProducerBatchSize { get; set; } = 1;
}
