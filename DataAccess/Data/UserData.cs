using DataAccess.DbAccess;
using DataAccess.Models;
namespace DataAccess.Data;

public class UserData : IUserData
{
    private string dbo = "fb_leandrosystem..";

    private readonly ISqlDataAccess _db;
    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task<User?> GetUser(int id)
    {
        var results = await _db.LoadData<User, dynamic>(
            storedProcedure: dbo + "spUser_Get",
            new { Id = id });

        return results.FirstOrDefault();
    }
    public async Task<User?> GetUserByLogin(string login)
    {
        var results = await _db.LoadData<User, dynamic>(
            storedProcedure: dbo + "spUser_GetByLogin",
            new { Login = login });

        return results.FirstOrDefault();
    }
    public Task<IEnumerable<User>> GetUsers() =>
        _db.LoadData<User, dynamic>(dbo + "spUser_GetAll", new { });

    public Task InsertUser(User user) =>
        _db.SaveData(storedProcedure: dbo + "spUser_Insert", new { user.Login, user.Password });

    public Task UpdateUser(User user) =>
        _db.SaveData(storedProcedure: dbo + "spUser_Update", user);

    public Task UpdateUserPassword(User user) =>
    _db.SaveData(storedProcedure: dbo + "spUser_UpdatePassword", user);

    public Task DeleteUser(int id) =>
        _db.SaveData(storedProcedure: dbo + "spUser_Delete", new { UserId = id });
}
