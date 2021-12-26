using System.Data;
using Dapper;
using Dofus.Hdv.Core.Aggregates.PricesAggregate;

namespace Dofus.Hdv.Infrastructure.Data
{
    public class PriceRepository : Core.Interfaces.PriceRepository
    {
        private readonly IDbConnection connection;

        public PriceRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task Create(Price price, CancellationToken cancellationToken = default)
        {
             await connection.ExecuteScalarAsync(
                @"INSERT INTO prices(dofus_id, server_id, value, created_at, created_by) 
                      VALUES (@DofusId, @ServerId, @CreatedAt, @CreatedBy);",
                price);
        }
    }
}