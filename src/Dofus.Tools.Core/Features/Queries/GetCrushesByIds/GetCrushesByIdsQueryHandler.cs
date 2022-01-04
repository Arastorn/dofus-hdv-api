using Dofus.Tools.Core.Aggregates.CrushesAggregate;
using Dofus.Tools.Core.Aggregates.PricesAggregate;
using Dofus.Tools.Core.Interfaces;
using MediatR;

namespace Dofus.Tools.Core.Features.Queries.GetCrushesByIds;

public class GetCrushesByIdsQueryHandler : IRequestHandler<GetCrushesByIdsQuery, Crush[]>
{
    private readonly CrushRepository crushesRepository;

    public GetCrushesByIdsQueryHandler(CrushRepository crushesRepository)
    {
        this.crushesRepository = crushesRepository;
    }

    public Task<Crush[]> Handle(GetCrushesByIdsQuery request, CancellationToken cancellationToken)
        => crushesRepository.GetCrushesByIds(request.DofusId, request.ServerId, cancellationToken);
}