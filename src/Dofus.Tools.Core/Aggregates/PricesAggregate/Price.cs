using NodaTime;

namespace Dofus.Tools.Core.Aggregates.PricesAggregate;

public class Price
{
    private Price(long dofusId, long serverId, long value, Instant createdAt, string createdBy)
    {
        DofusId = dofusId;
        Value = value;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
        ServerId = serverId;
    }

    public long DofusId { get; private set; }
    public long ServerId { get; private set; }
    public long Value { get; private set; }
    public Instant CreatedAt { get; private set; }
    public string CreatedBy { get; private set; }

    public static Price Create(long dofusId, long serverId, long value, Instant createdAt, string createdBy)
    {
        return new Price(dofusId, serverId, value, createdAt, createdBy);
    }
}