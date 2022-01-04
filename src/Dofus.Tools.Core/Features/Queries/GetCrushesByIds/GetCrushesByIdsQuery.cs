using Dofus.Tools.Core.Aggregates.CrushesAggregate;
using Dofus.Tools.Core.Aggregates.PricesAggregate;
using MediatR;

namespace Dofus.Tools.Core.Features.Queries.GetCrushesByIds;

public record GetCrushesByIdsQuery(int DofusId, short ServerId) : IRequest<Crush[]>;