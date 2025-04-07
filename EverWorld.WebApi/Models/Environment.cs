using System.ComponentModel.DataAnnotations;

public class Environment
{
    public int Id { get; set; }
    [Required]
    [StringLength(25, MinimumLength = 1)]
    required public string Name { get; set; }
    [Required]
    [Range(10, 100)]
    public int MaxHeight { get; set; }
    [Required]
    [Range(20, 200)]
    public int MaxLength { get; set; }
    public string ?UserId { get; set; }

}