using Dofus.Tools.Core.Aggregates.PricesAggregate;
using Dofus.Tools.Core.Interfaces;
using MediatR;

namespace Dofus.Tools.Core.Features.Commands;

public class CreatePriceCommandHandler : IRequestHandler<CreatePriceCommand>
{
    private readonly PriceRepository priceRepository;

    public CreatePriceCommandHandler(PriceRepository priceRepository)
    {
        this.priceRepository = priceRepository;
    }

    public async Task<Unit> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
    {
        await priceRepository.Create(
            Price.Create(
                request.DofusId,
                request.ServerId,
                request.Value,
                request.CreatedAt,
                request.CreatedBy),
            cancellationToken);

        return Unit.Value;
    }
}