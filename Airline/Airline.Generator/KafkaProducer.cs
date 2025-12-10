using Confluent.Kafka;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Airline.Generator;

/// <summary>
/// Background Kafka producer service responsible for generating and sending
/// ticket events to the configured Kafka topic in a batch and interval-based manner.
/// </summary>
public class KafkaProducer(
    IOptions<KafkaOptions> options,
    IProducer<Null, string> producer,
    ILogger<KafkaProducer> logger
) : BackgroundService
{
    private readonly KafkaOptions _options = options.Value;

    /// <summary>
    /// Main execution loop of the Kafka producer.  
    /// Generates ticket events, serializes them to JSON and sends them to Kafka using the configured producer.
    /// </summary>
    protected override async Task ExecuteAsync(CancellationToken stopToken)
    {
        logger.LogInformation(
            "KafkaProducer started with IntervalMs={IntervalMs}, BatchSize={BatchSize}, Topic={Topic}",
            _options.ProducerIntervalMs,
            _options.ProducerBatchSize,
            _options.Topic);

        while (!stopToken.IsCancellationRequested)
        {
            try
            {
                for (var i = 0; i < _options.ProducerBatchSize; ++i)
                {
                    var dto = Generator.GenerateTickets(1).First();
                    var json = JsonSerializer.Serialize(dto);

                    logger.LogInformation("Generating ticket event {msg}", json);

                    await producer.ProduceAsync(
                        _options.Topic,
                        new Message<Null, string> { Value = json },
                        stopToken);
                }

                await Task.Delay(_options.ProducerIntervalMs, stopToken);
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