using Dofus.Tools.Core.Aggregates.PricesAggregate;
using MediatR;

namespace Dofus.Tools.Core.Features.Queries.GetPricesByDofusId;

public record GetPricesByDofusIdQuery(int DofusId, short ServerId) : IRequest<Price[]>;