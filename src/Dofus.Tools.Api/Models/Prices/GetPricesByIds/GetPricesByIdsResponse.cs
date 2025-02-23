﻿using Dofus.Tools.Core.Aggregates.PricesAggregate;
using NodaTime;

namespace Dofus.Tools.Api.Models.Prices.GetPricesByIds;

public record GetPricesByIdsResponse(Guid Id, long DofusId, long ServerId, long Value, long EstimatedCrushValue, Instant CreatedAt, string CreatedBy)
{
    public static implicit operator GetPricesByIdsResponse(Price price)
        => new GetPricesByIdsResponse(price.Id, price.DofusId, price.ServerId, price.Value, price.EstimatedCrushValue, price.CreatedAt, price.CreatedBy);
}