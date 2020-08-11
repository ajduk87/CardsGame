using Npgsql;

namespace CardsGameServerQuery
{
    public interface IDatabaseConnectionFactory
    {
        IDatabaseConnectionFactory Instance { get; }

        NpgsqlConnection Create(string connectionStringParam = null);
    }
}