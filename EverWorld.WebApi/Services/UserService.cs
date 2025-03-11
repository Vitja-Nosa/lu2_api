using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Dapper;
using EverWorld.WebApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;

public class UserService
{
    private readonly IDbConnection dbConnection;

    public UserService(DbConnectionService dbConnectionService)
    {
        dbConnection = dbConnectionService.Connection;
    }

    public async Task<User?> GetLoggedUserAsync(string token)
    {
        using (var connection = dbConnection)
        {
            var user = await connection.QueryFirstOrDefaultAsync<User>(
                "SELECT * FROM Auth.AspNetUsers WHERE Id = @Token",
                new { Token = "df54207f-6da8-4bb2-92cb-eedd80aa5a16" });
            return user;
        }
    }
}