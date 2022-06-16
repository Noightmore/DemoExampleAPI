using Dapper;

namespace DataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadDataAsync<T>(
        string sqlQuery,
        DynamicParameters parameters,
        string connectionId = "Default");

    Task SaveDataAsync<T>(
        string sqlQuery,
        T parameters,
        string connectionId = "Default");
}