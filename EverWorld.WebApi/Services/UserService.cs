using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Dapper;
using EverWorld.WebApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration.UserSecrets;

public class UserService {
    private readonly IDbConnection dbConnection;
    private readonly IAuthenticationService _authenticationService;

    public UserService(DbConnectionService dbConnectionService, IAuthenticationService authenticationService)
    {
        dbConnection = dbConnectionService.Connection;
        _authenticationService = authenticationService;
    }

    public async Task<User?> GetLoggedUserAsync()
    {
        string userId = _authenticationService.GetCurrentAuthenticatedUserId();
        using (var connection = dbConnection)
        {
            var user = await connection.QueryFirstOrDefaultAsync<User>(
                "SELECT * FROM Auth.AspNetUsers WHERE Id = @uid",
                new { uid = userId});
            return user;
        }
    }
}