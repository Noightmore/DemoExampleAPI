namespace DataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadDataAsync<T,TU>(
        string postgresFunctionName,
        TU parameters,
        string connectionId = "Default");

    Task SaveDataAsync<T>(
        string postgresFunctionName,
        T parameters,
        string connectionId = "Default");
}