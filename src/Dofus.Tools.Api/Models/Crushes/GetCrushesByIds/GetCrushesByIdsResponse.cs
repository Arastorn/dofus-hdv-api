using Dofus.Tools.Core.Aggregates.CrushesAggregate;
using NodaTime;

namespace Dofus.Tools.Api.Models.Crushes.GetCrushesByIds;

public record GetCrushesByIdsResponse(Guid Id, long DofusId, long ServerId, long Value, Instant CreatedAt, string CreatedBy)
{
    public static implicit operator GetCrushesByIdsResponse(Crush crush)
        => new GetCrushesByIdsResponse(crush.Id, crush.DofusId, crush.ServerId, crush.Value, crush.CreatedAt, crush.CreatedBy);
}