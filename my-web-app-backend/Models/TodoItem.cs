using System.ComponentModel.DataAnnotations;

namespace my_web_app_backend.Models;
public class TodoItem
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}