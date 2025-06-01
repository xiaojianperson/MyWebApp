using System.ComponentModel.DataAnnotations;

namespace my_web_app_backend.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
}