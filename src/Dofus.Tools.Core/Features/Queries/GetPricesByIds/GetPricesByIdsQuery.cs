using Dofus.Tools.Core.Aggregates.PricesAggregate;
using MediatR;

namespace Dofus.Tools.Core.Features.Queries.GetPricesByIds;

public record GetPricesByIdsQuery(int DofusId, short ServerId) : IRequest<Price[]>;