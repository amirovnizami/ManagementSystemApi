using Microsoft.Data.SqlClient;

namespace ManagementSystem.DAL.SqlServer.Infrastructure;

public class BaseSqlRepository(string connectionString)
{
    private readonly string _connectionString = connectionString;

    protected SqlConnection OpenConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection;
    }
}