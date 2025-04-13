using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Dapper;
using EverWorld.WebApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;

public class DbConnectionService
{
    private readonly string _connectionString;
    public IDbConnection GetConnection() => new SqlConnection(_connectionString);
    public DbConnectionService (string connectionString)
    {
        _connectionString = connectionString;
    }
}