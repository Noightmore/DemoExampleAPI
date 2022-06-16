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
        string sqlQuery,
        TU parameters,
        string connectionId = "Default")
    {
        await using var connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));
        //connection.Open();
        await connection.OpenAsync();

        var users = await connection.QueryAsync<T>(
            sqlQuery,
            param: parameters,
            commandType: CommandType.StoredProcedure
            );
        
        return users;
    }
    
    // TODO
    public async Task SaveDataAsync<T>(
        string sqlQuery,
        T parameters,
        string connectionId = "Default")
    {
        await using var connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));
        await connection.OpenAsync();

        await connection.ExecuteAsync(
            sqlQuery,
            parameters,
            commandType: CommandType.StoredProcedure
            );
    }
}