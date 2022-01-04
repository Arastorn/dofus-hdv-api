using Dofus.Tools.Core.Aggregates.PricesAggregate;

namespace Dofus.Tools.Core.Interfaces;

public interface PriceRepository
{
    Task Create(Price price, CancellationToken cancellationToken = default);
    Task<Price[]> GetPricesByDofusId(long dofusId, short serverId, CancellationToken cancellationToken = default);
}