using System.ComponentModel.DataAnnotations;

namespace EverWorld.WebApi.Models;
public class Object2d
{
    [Required]
    public float PositionX { get; set; }
    [Required]
    public float PositionY { get; set; }
    [Required]
    public int PrefabId { get; set;  }
    public int Id { get; set; }
    [Required]

    public int EnvironmentId { get; set; }
}