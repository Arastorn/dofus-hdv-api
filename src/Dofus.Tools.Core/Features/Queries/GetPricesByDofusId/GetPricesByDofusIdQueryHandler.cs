using Dofus.Tools.Core.Aggregates.PricesAggregate;
using Dofus.Tools.Core.Interfaces;
using MediatR;

namespace Dofus.Tools.Core.Features.Queries.GetPricesByDofusId;

public class GetPricesByDofusIdQueryHandler : IRequestHandler<GetPricesByDofusIdQuery, Price[]>
{
    private readonly PriceRepository priceRepository;

    public GetPricesByDofusIdQueryHandler(PriceRepository priceRepository)
    {
        this.priceRepository = priceRepository;
    }

    public Task<Price[]> Handle(GetPricesByDofusIdQuery request, CancellationToken cancellationToken)
        => priceRepository.GetPricesByIds(request.DofusId, request.ServerId, cancellationToken);
}