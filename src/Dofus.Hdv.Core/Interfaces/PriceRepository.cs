using Dofus.Hdv.Core.Aggregates.PricesAggregate;

namespace Dofus.Hdv.Core.Interfaces;

public interface PriceRepository
{
    Task Create(Price price, CancellationToken cancellationToken = default);
}