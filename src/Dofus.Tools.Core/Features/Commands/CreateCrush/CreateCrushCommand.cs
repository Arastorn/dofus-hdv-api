using MediatR;

namespace Dofus.Tools.Core.Features.Commands.CreateCrush;

public record CreateCrushCommand(
    long DofusId,
    short ServerId,
    long Value,
    string CreatedBy) : IRequest;