namespace ApiFinalmente;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        // All of my API endpoint mapping
        app.MapPost(pattern: "/GetAllUsers", GetUsers);
        app.MapPost(pattern: "/GetUser", GetUser);
        app.MapPost(pattern: "/User/CreateUser", CreateUser);
        app.MapPost(pattern: "/User/EditLogin", UpdateUser);
        app.MapPost(pattern: "/Users/EditPassword", UpdateUserPassword);
        app.MapPost(pattern: "/User/DeleteUser", DeleteUser);
    }

    private static async Task<IResult> GetUsers(IUserData data)
    {
        try
        {
            return Results.Ok(await data.GetUsers());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetUser(User user, IUserData data)
    {
        try
        {
            var results = await data.GetUser(user.UserId);
            if (results == null) return Results.NotFound("Usuário não Encontrado");
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> CreateUser(User user, IUserData data)
    {
        try
        {
            Validate.ValidatePassword(user.Password);
            var results = await data.GetUserByLogin(user.Login);
            if (results != null) throw new Exception("There is already User with this login");

            await data.InsertUser(user);
            return Results.Ok("User has been added!");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(User user, IUserData data)
    {
        try
        {
            await data.UpdateUser(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateUserPassword(User user, IUserData data)
    {
        try
        {
            await data.UpdateUserPassword(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteUser(User user , IUserData data)
    {
        try
        {
            await data.DeleteUser(user.UserId);
            return Results.Ok("User has Been Deleted");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
