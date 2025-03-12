using System.ComponentModel.DataAnnotations;

namespace EverWorld.WebApi.Models;
public class Object2d
{
    public float PositionX { get; set; }
    public float PositionY { get; set; }
    public int PrefabId { get; set;  }
    public int Id { get; set; }

    public int EnvironmentId { get; set; }
}