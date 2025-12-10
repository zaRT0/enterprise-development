namespace Airline.Generator;

/// <summary>
/// Configuration options for the Kafka producer used in the ticket generation service.
/// Contains settings such as topic name, message batch size, and production interval.
/// </summary>
public class KafkaOptions
{
    public string Topic { get; set; } = "ticket-events";

    public int ProducerIntervalMs { get; set; } = 5000;

    public int ProducerBatchSize { get; set; } = 1;
}
