using Dofus.Tools.Core.Aggregates.PricesAggregate;
using Dofus.Tools.Core.Interfaces;
using MediatR;
using NodaTime;

namespace Dofus.Tools.Core.Features.Commands.CreatePrice;

public class CreatePriceCommandHandler : IRequestHandler<CreatePriceCommand>
{
    private readonly PriceRepository priceRepository;
    private readonly IClock clock;

    public CreatePriceCommandHandler(PriceRepository priceRepository, IClock clock)
    {
        this.priceRepository = priceRepository;
        this.clock = clock;
    }

    public async Task<Unit> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
    {
        await priceRepository.Create(
            Price.Create(
                request.DofusId,
                request.ServerId,
                request.Value,
                request.EstimatedCrushValue,
                clock.GetCurrentInstant(),
                request.CreatedBy),
            cancellationToken);

        return Unit.Value;
    }
}