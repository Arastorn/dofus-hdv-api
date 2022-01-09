using Dofus.Tools.Core.Interfaces;
using NodaTime;

namespace Dofus.Tools.Core.Aggregates.PricesAggregate;

public class Price : IAggregateRoot
{
    private Price()
    {
    }

    private Price(Guid id, long dofusId, short serverId, long value, long estimatedCrushValue,  Instant createdAt, string createdBy)
    {
        Id = id;
        DofusId = dofusId;
        Value = value;
        EstimatedCrushValue = estimatedCrushValue;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
        ServerId = serverId;
    }

    public Guid Id { get; }
    public long DofusId { get; private set; }
    public short ServerId { get; private set; }
    public long Value { get; private set; }
    public long EstimatedCrushValue { get; }
    public Instant CreatedAt { get; private set; }
    public string CreatedBy { get; private set; } = default!;

    public static Price Create(long dofusId, short serverId, long value, long estimatedCrushValue, Instant createdAt, string createdBy)
    {
        return new Price(Guid.NewGuid(), dofusId, serverId, value, estimatedCrushValue, createdAt, createdBy);
    }
}