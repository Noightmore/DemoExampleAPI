using Dapper;
using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class UserData : IUserData
{
    private const string GetAllUsersFunction = "user_getall()";
    private const string GetUserById = "user_getone_byid(@id)";
    private readonly ISqlDataAccess _db;
    
    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    private const string QueryToGetAllUsers = $"SELECT * FROM {GetAllUsersFunction}";
    public Task<IEnumerable<UserModel>> GetUsers() =>
        _db.LoadDataAsync<UserModel>(QueryToGetAllUsers, new DynamicParameters());
    
    
    private const string QueryToGetUserById = $"SELECT * FROM {GetUserById}";
    public async Task<UserModel?> GetUser(int id)
    {
        var dynamicParams = new DynamicParameters();
        dynamicParams.Add("@id", id);
        
        var result = await _db.LoadDataAsync<UserModel>(
            QueryToGetUserById,
            dynamicParams
            );
        
        return result.FirstOrDefault();
    }
    
    // sus
    public Task InsertUser(UserModel user) => _db.SaveDataAsync(
        "user_insert_newuser",
        new {FirstName = user.UFirstName, LastName = user.ULastName, Gender = user.UGender, Email = user.UEmail,
            BirthDate = user.UBirthDate});

    public Task DeleteUser(int id) => 
        _db.SaveDataAsync("user_deleteone_byid", new {Id = id});
}