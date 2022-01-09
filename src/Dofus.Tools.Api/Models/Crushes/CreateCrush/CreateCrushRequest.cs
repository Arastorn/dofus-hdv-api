namespace Dofus.Tools.Api.Models.Crushes.CreateCrush;

public record CreateCrushRequest(
    long DofusId,
    short ServerId,
    long Value,
    string CreatedBy);