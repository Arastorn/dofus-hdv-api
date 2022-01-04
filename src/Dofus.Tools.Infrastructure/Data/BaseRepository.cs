using Npgsql;

namespace Dofus.Tools.Infrastructure.Data;

public class BaseRepository
{
    private readonly string connectionString;

    protected BaseRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    protected NpgsqlConnection GetConnection() => new(connectionString);
}