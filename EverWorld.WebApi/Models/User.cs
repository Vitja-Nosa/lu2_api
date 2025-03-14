using System.ComponentModel.DataAnnotations;

namespace EverWorld.WebApi.Models;
public class User
{
    public string Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}