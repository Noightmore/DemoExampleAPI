using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DataAccess.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadDataAsync<T,TU>(
        string postgresFunctionName,
        TU parameters,
        string connectionId = "Default")
    {
        await using var connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));
        await connection.OpenAsync();

        var users = await connection.QueryAsync<T>(
            postgresFunctionName,
            param: parameters,
            commandType: CommandType.StoredProcedure
            );
        
        return users;
    }
    
    public async Task SaveDataAsync<T>(
        string postgresFunctionName,
        T parameters,
        string connectionId = "Default")
    {
        await using var connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));
        await connection.OpenAsync();

        await connection.ExecuteAsync(
            postgresFunctionName,
            parameters,
            commandType: CommandType.StoredProcedure
            );
    }
}