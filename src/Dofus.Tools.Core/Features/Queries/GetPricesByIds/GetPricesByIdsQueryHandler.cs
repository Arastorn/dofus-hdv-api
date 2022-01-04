using Dofus.Tools.Core.Aggregates.PricesAggregate;
using Dofus.Tools.Core.Interfaces;
using MediatR;

namespace Dofus.Tools.Core.Features.Queries.GetPricesByIds;

public class GetPricesByIdsQueryHandler : IRequestHandler<GetPricesByIdsQuery, Price[]>
{
    private readonly PriceRepository priceRepository;

    public GetPricesByIdsQueryHandler(PriceRepository priceRepository)
    {
        this.priceRepository = priceRepository;
    }

    public Task<Price[]> Handle(GetPricesByIdsQuery request, CancellationToken cancellationToken)
        => priceRepository.GetPricesByIds(request.DofusId, request.ServerId, cancellationToken);
}