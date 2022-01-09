using MediatR;
using NodaTime;

namespace Dofus.Tools.Core.Features.Commands.CreatePrice;

public record CreatePriceCommand(
    long DofusId,
    short ServerId,
    long Value,
    long EstimatedCrushValue,
    string CreatedBy) : IRequest;