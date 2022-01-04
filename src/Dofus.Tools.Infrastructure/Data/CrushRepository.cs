using Dapper;
using Dofus.Tools.Core.Aggregates.CrushesAggregate;

namespace Dofus.Tools.Infrastructure.Data;

public class CrushRepository : BaseRepository, Core.Interfaces.CrushRepository
{
    public CrushRepository(string connectionString)
        : base(connectionString)
    {
    }

    public async Task Create(Crush crush, CancellationToken cancellationToken = default)
    {
        await using var connection = GetConnection();
        await connection.ExecuteScalarAsync(
            @"INSERT INTO crushes(id, dofus_id, server_id, value, created_at, created_by) 
                      VALUES (@id, @DofusId, @ServerId, @Value, @CreatedAt, @CreatedBy);",
            crush);
    }
}