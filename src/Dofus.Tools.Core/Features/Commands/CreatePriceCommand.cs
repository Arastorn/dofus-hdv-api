using MediatR;
using NodaTime;

namespace Dofus.Tools.Core.Features.Commands;

public record CreatePriceCommand(
    long DofusId,
    long ServerId,
    long Value,
    Instant CreatedAt,
    string CreatedBy) : IRequest;