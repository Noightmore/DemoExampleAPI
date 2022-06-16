namespace DataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadDataAsync<T,TU>(
        string sqlQuery,
        TU parameters,
        string connectionId = "Default");

    Task SaveDataAsync<T>(
        string sqlQuery,
        T parameters,
        string connectionId = "Default");
}