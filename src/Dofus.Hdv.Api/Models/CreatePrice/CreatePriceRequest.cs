using NodaTime;

namespace Dofus.Hdv.Api.Models.CreatePrice;

public record CreatePriceRequest(
    long DofusId,
    long ServerId,
    long Value,
    Instant CreatedAt,
    string CreatedBy);