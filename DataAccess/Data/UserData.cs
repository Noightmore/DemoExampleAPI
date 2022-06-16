using System.Globalization;
using Dapper;
using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;
    
    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }
    
    public Task<IEnumerable<UserModel>> GetUsers() =>
        _db.LoadDataAsync<UserModel, dynamic>("user_getall", new {});
    
    // POJMENOVAVAT SPRAVNE PROMMENY JINAK DAPPER SUSUJE
    public async Task<UserModel?> GetUser(int id)
    {
       var result = await _db.LoadDataAsync<UserModel, dynamic>
           ("user_getone_byid", new { id_in = id });
       return result.FirstOrDefault();
    }
    
    public Task InsertUser(UserModel user)
    {
        return _db.SaveDataAsync(
            "user_insert_newuser",
            new
            {
                first_n = user.UFirstName,
                last_n = user.ULastName,
                gender_in = user.UGender,
                email_in = user.UEmail,
                date_of_birth_in = user.UBirthDate.ToString(CultureInfo.CurrentCulture)
            }
        );
    }

    public Task UpdateUser(UserModel user) => 
        _db.SaveDataAsync("user_updateinstance", new
        {
            id_in = user.UID,
            first_n = user.UFirstName,
            last_n = user.ULastName,
            gender_in = user.UGender,
            email_in = user.UEmail,
            date_of_birth_in = user.UBirthDate.ToString(CultureInfo.CurrentCulture)
        });
    
    public Task DeleteUser(int id) => 
        _db.SaveDataAsync("user_deleteone_byid", new {Id = id});
}