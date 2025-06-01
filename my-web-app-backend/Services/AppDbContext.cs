using Microsoft.EntityFrameworkCore;
using my_web_app_backend.Models;

namespace my_web_app_backend.Services;
public class AppDbContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // 使用 SQLite 数据库文件（默认保存在项目目录下）
        optionsBuilder.UseSqlite("Data Source=app.db");
    }
}