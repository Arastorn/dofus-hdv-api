using MediatR;
using NodaTime;

namespace Dofus.Hdv.Core.Features.Commands;

public record CreatePriceCommand(
    long DofusId,
    long ServerId,
    long Value,
    Instant CreatedAt,
    string CreatedBy) : IRequest;