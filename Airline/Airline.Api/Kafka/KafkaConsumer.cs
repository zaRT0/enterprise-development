using Airline.Domain.Entities;
using Airline.Domain.Interfaces;
using Airline.Dtos.TicketDtos;
using AutoMapper;
using Confluent.Kafka;
using System.Text.Json;

namespace Airline.Api.Kafka;

/// <summary>
/// Background service responsible for consuming ticket event messages from Kafka,
/// Deserializing them into DTO objects, and persisting them into the application's data store.
/// </summary>
public class KafkaConsumer(
    IConfiguration configuration,
    IConsumer<Ignore, string> consumer,
    IServiceScopeFactory serviceScopeFactory,
    IMapper mapper,
    ILogger<KafkaConsumer> logger
) : BackgroundService
{
    private readonly string _topic = configuration["KafkaTopic"] ?? "ticket-events";

    /// <summary>
    /// Main execution loop of the Kafka consumer.  
    /// Subscribes to the configured topic, reads messages continuously, deserializes ticket DTOs, maps them to domain entities,
    /// and saves them to the repository layer.
    /// </summary>
    protected override async Task ExecuteAsync(CancellationToken stopToken)
    {
        consumer.Subscribe(_topic);
        logger.LogInformation("KafkaConsumer is starting. Subscribing to topic: {Topic}", _topic);
        while (!stopToken.IsCancellationRequested)
        {
            try
            {
                var consumeResult = consumer.Consume(stopToken);

                if (string.IsNullOrEmpty(consumeResult?.Message?.Value))
                {
                    logger.LogWarning("An empty message was received");
                    continue;
                }

                var offset = consumeResult.TopicPartitionOffset;
                logger.LogDebug("Processing message at {Offset}", offset);

                var ticketDto = JsonSerializer.Deserialize<TicketEditDto>(
                    consumeResult.Message.Value,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (ticketDto == null)
                {
                    logger.LogWarning("Skipped invalid message at {Offset}: unable to deserialize", offset);
                    continue;
                }

                using var scope = serviceScopeFactory.CreateScope();
                var repo = scope.ServiceProvider.GetRequiredService<IRepository<Ticket>>();
                var entity = mapper.Map<Ticket>(ticketDto);
                await repo.AddAsync(entity);
                logger.LogInformation("Persisted ticket for PassengerId={PassengerId} on FlightId={FlightId}",
                    ticketDto.PassengerId, ticketDto.FlightId);

                consumer.Commit(consumeResult);
            }
            catch (ConsumeException ex)
            {
                logger.LogError(ex, "Kafka consumption failed");
            }
            catch (OperationCanceledException)
            {   
                break;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error during message processing");
            }
        }

        consumer.Close();
        logger.LogInformation("Kafka consumer stopped");
    }
}
