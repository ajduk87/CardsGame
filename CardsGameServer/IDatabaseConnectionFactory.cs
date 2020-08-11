using Npgsql;

namespace CardsGameServer
{
    public interface IDatabaseConnectionFactory
    {
        IDatabaseConnectionFactory Instance { get; }

        NpgsqlConnection Create(string connectionStringParam = null);
    }
}