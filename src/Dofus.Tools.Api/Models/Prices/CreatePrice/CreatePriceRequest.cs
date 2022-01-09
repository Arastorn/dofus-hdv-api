namespace Dofus.Tools.Api.Models.Prices.CreatePrice;

public record CreatePriceRequest(
    long DofusId,
    short ServerId,
    long Value,
    long EstimatedCrushValue,
    string CreatedBy);