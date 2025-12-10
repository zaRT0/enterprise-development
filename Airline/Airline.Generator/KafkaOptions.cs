namespace Airline.Generator;

/// <summary>
/// 
/// </summary>
public class KafkaOptions
{
    public string Topic { get; set; } = "ticket-events";
    public int ProducerIntervalMs { get; set; } = 5000;
    public int ProducerBatchSize { get; set; } = 1;
}
