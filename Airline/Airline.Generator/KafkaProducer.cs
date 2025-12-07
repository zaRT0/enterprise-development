using System.Text.Json;
using Confluent.Kafka;

namespace Airline.Generator;

/// <summary>
/// Background Kafka producer service responsible for generating and sending
/// ticket events to the configured Kafka topic in a batch and interval-based manner.
/// </summary>
public class KafkaProducer(
    IConfiguration configuration,
    IProducer<Null, string> producer,
    ILogger<KafkaProducer> logger
) : BackgroundService
{
    private readonly int _intervalMs = int.TryParse(configuration["KafkaProducerIntervalMs"], out var a) ? a : 5000;
    private readonly int _batchSize = int.TryParse(configuration["KafkaProducerBatchSize"], out var b) ? b : 1;
    private readonly string _topic = configuration["KafkaTopic"] ?? "ticket-events";

    /// <summary>
    /// Main execution loop of the Kafka producer.  
    /// Generates ticket events, serializes them to JSON and sends them to Kafka using the configured producer.
    /// </summary>
    protected override async Task ExecuteAsync(CancellationToken stopToken)
    {
        logger.LogInformation(
            "KafkaProducer started with IntervalMs={IntervalMs}, BatchSize={BatchSize}, Topic={Topic}",
            _intervalMs,
            _batchSize,
            _topic);

        while (!stopToken.IsCancellationRequested)
        {
            try
            {
                for (var i = 0; i < _batchSize; ++i)
                {
                    var dto = Generator.GenerateTickets(1).First();
                    var json = JsonSerializer.Serialize(dto);

                    logger.LogInformation("Generating ticket event {msg}", json);

                    await producer.ProduceAsync(
                        _topic,
                        new Message<Null, string> { Value = json },
                        stopToken);
                }

                await Task.Delay(_intervalMs, stopToken);
            }
            catch (OperationCanceledException)
            {
                logger.LogInformation("KafkaProducer received cancellation request");
                break;
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "KafkaProducer failed to produce message to Kafka topic");
            }
        }

        logger.LogInformation("KafkaProducer stopped");
    }
}