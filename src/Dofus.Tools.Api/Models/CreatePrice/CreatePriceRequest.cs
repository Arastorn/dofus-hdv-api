using NodaTime;

namespace Dofus.Tools.Api.Models.CreatePrice;

public record CreatePriceRequest(
    long DofusId,
    short ServerId,
    long Value,
    string CreatedBy);