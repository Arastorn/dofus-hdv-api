using NodaTime;

namespace Dofus.Tools.Api.Models.CreatePrice;

public record CreatePriceRequest(
    long DofusId,
    long ServerId,
    long Value,
    Instant CreatedAt,
    string CreatedBy);