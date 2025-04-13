using Dapper;
using EverWorld.WebApi.Models;
using System.Data;

public class ObjectService
{
    private readonly IDbConnection dbConnection;

    public ObjectService(DbConnectionService dbConnectionService)
    {
        dbConnection = dbConnectionService.GetConnection();
    }

    public async Task<IEnumerable<Object2d>> GetObjects(int id)
    {
        using (var connection = dbConnection)
        {
            IEnumerable<Object2d>? object2ds = await connection.QueryAsync<Object2d>(
               "SELECT * FROM Object2ds WHERE EnvironmentId = @param",
                new { param = id });
            return object2ds;
        }

    }

    public async Task CreateObject(Object2d obj)
    {
        using (var connection = dbConnection)
        {
            var result = await connection.ExecuteAsync(
               "INSERT INTO dbo.Object2ds (PositionX, PositionY, EnvironmentId, PrefabId) VALUES (@PositionX, @PositionY, @EnvironmentId, @PrefabId)",
               new
               {
                    PositionX = obj.PositionX,
                    PositionY = obj.PositionY,
                    PrefabId = obj.PrefabId,
                    EnvironmentId = obj.EnvironmentId
               });
        }

    }
}