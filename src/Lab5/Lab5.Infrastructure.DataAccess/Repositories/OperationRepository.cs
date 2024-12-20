using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Operations;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class OperationRepository : IOperationRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<Operation> GetOperationsByUserId(long userId)
    {
        const string sql = """
                           select *
                           from OperationHistory
                           where AccountId = @userId;
                           """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@userId", userId);

        using NpgsqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (Enum.TryParse(reader.GetString(2), out OperationType type))
            {
                yield return new Operation(
                    accountId: reader.GetInt64(1),
                    operationType: type,
                    amount: reader.GetDecimal(3));
            }
            else
            {
                throw new Exception("Invalid operation type");
            }
        }
    }
}