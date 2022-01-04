using Dofus.Tools.Core.Aggregates.PricesAggregate;
using NodaTime;

namespace Dofus.Tools.Api.Models.GetPricesByDofusId;

public record GetPricesByDofusIdResponse(Guid Id, long DofusId, long ServerId, long Value, Instant CreatedAt, string CreatedBy)
{
    public static implicit operator GetPricesByDofusIdResponse(Price price)
        => new GetPricesByDofusIdResponse(price.Id, price.DofusId, price.ServerId, price.Value, price.CreatedAt, price.CreatedBy);
}