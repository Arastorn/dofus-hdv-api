﻿using Dofus.Hdv.Core.Aggregates.PricesAggregate;
using Dofus.Hdv.Core.Interfaces;
using MediatR;

namespace Dofus.Hdv.Core.Features.Commands;

public class CreatePriceCommandHandler : IRequestHandler<CreatePriceCommand>
{
    private readonly PriceRepository priceRepository;

    public CreatePriceCommandHandler(PriceRepository priceRepository)
    {
        this.priceRepository = priceRepository;
    }

    public Task<Unit> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
    {
        priceRepository.Create(
            Price.Create(
                request.DofusId,
                request.ServerId,
                request.Value,
                request.CreatedAt,
                request.CreatedBy),
            cancellationToken);

        return Unit.Task;
    }
}