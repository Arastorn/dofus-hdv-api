using System.Data;
using Dapper;
using Dofus.Tools.Core.Aggregates.PricesAggregate;

namespace Dofus.Tools.Infrastructure.Data
{
    public class PriceRepository : BaseRepository, Core.Interfaces.PriceRepository
    {
        public PriceRepository(string connectionString)
            : base(connectionString)
        {
        }

        public async Task Create(Price price, CancellationToken cancellationToken = default)
        {
            await using var connection = GetConnection();
            await connection.ExecuteScalarAsync(
                @"INSERT INTO prices(dofus_id, server_id, value, created_at, created_by) 
                      VALUES (@DofusId, @ServerId, @Value, @CreatedAt, @CreatedBy);",
                price);
        }
    }
}