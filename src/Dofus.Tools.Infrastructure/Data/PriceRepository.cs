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
                @"INSERT INTO prices(id, dofus_id, server_id, value, estimated_crush_value, created_at, created_by) 
                      VALUES (@id, @DofusId, @ServerId, @Value, @EstimatedCrushValue, @CreatedAt, @CreatedBy);",
                price);
        }

        public async Task<Price[]> GetPricesByIds(long dofusId, short serverId, CancellationToken cancellationToken = default)
        {
            await using var connection = GetConnection();
            return (await connection.QueryAsync<Price>(
                @"SELECT * FROM prices WHERE dofus_id = @DofusId AND server_id = @ServerId",
                new { DofusId = dofusId, ServerId = serverId })).ToArray();
        }
    }
}