using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Dapper;
using EverWorld.WebApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

public class EnvironmentService
{
    private readonly DbConnectionService dbConnection;

    public EnvironmentService(DbConnectionService dbConnectionService)
    {
        dbConnection = dbConnectionService;
    }

    public async Task<Environment> CreateEnvironment(Environment environment)
    {
        using (var connection = dbConnection.GetConnection())
        {
            var result = await connection.ExecuteAsync(
               "INSERT INTO Environments (UserId, Name, MaxLength, MaxHeight) VALUES (@userid, @name, @maxLength, @maxHeight)",
               new
               {
                   userid = environment.UserId,
                   name = environment.Name,
                   maxLength = environment.MaxLength,
                   maxHeight = environment.MaxHeight,

               });
            Debug.WriteLine(result);
            return environment;
        }
    }

    public async Task<IEnumerable<Environment>?> GetUserEnvironments(string userId)
    {
        using (var connection = dbConnection.GetConnection())
        {
             IEnumerable<Environment>? environments = await connection.QueryAsync<Environment>(
                "SELECT * FROM dbo.Environments WHERE UserId = @param",
                new { param = userId });
             return environments;
        }
    }

    public async Task DeleteEnvironment(int id)
    {
        using (var connection = dbConnection.GetConnection())
        {
             IEnumerable<Environment>? environments = await connection.QueryAsync<Environment>(
                "DELETE FROM dbo.Environments WHERE id = @param",
                 new { param = id });
        }
    }

    public async Task DeleteEnvironmentObjects(int id)
    {
        using (var con = dbConnection.GetConnection())
        {
            IEnumerable<Environment>? environments = await con.QueryAsync<Environment>(
               "DELETE FROM dbo.Object2ds WHERE EnvironmentId = @param",
                new { param = id });
        }
    }


}