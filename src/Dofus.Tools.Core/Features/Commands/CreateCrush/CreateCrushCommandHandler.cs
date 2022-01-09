using Dofus.Tools.Core.Aggregates.CrushesAggregate;
using Dofus.Tools.Core.Interfaces;
using MediatR;
using NodaTime;

namespace Dofus.Tools.Core.Features.Commands.CreateCrush;

public class CreateCrushCommandHandler : IRequestHandler<CreateCrushCommand>
{
    private readonly IClock clock;
    private readonly CrushRepository crushRepository;

    public CreateCrushCommandHandler(IClock clock, CrushRepository crushRepository)
    {
        this.clock = clock;
        this.crushRepository = crushRepository;
    }

    public async Task<Unit> Handle(CreateCrushCommand request, CancellationToken cancellationToken)
    {
        await crushRepository.Create(
            Crush.Create(
                request.DofusId,
                request.ServerId,
                request.Value,
                clock.GetCurrentInstant(),
                request.CreatedBy),
            cancellationToken);

        return Unit.Value;
    }
}