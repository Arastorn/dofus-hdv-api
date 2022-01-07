using Dofus.Tools.Core.Aggregates.CrushesAggregate;

namespace Dofus.Tools.Core.Interfaces;

public interface CrushRepository
{
    Task Create(Crush crush, CancellationToken cancellationToken = default);
    Task<Crush[]> GetCrushesByIds(long dofusId, short serverId, CancellationToken cancellationToken = default);
}