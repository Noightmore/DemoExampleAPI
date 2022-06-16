namespace MinimalAPIdemo1;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        // All of mapping
        app.MapGet("/Users", GetUsersData);
        app.MapGet("/Users/{id:int}", GetUser);
        app.MapPost("/Users", InsertUser);
        // app.MapPut("/Users", UpdateUser);
        app.MapDelete("/Users", DeleteUser);
    }
    
    // IResult Result - provides wrapper that wraps the received data in http codes
    private static async Task<IResult> GetUsersData(IUserData data)
    {
        try
        {
            return Results.Ok(await data.GetUsers());
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> GetUser(int id, IUserData data)
    {
        try
        {
            var result = await data.GetUser(id);
            return result == null ? Results.NotFound() : Results.Ok(result);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    private static async Task<IResult> InsertUser(UserModel user, IUserData data)
    {
        try
        {
            await data.InsertUser(user);
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }
    
    private static async Task<IResult> DeleteUser(int id, IUserData data)
    {
        try
        {
            await data.DeleteUser(id);
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }
}