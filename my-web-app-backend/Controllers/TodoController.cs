using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_web_app_backend.Models;
using my_web_app_backend.Services;

namespace my_web_app_backend.Controllers;
[ApiController]
[Route("[controller]")]
public class TodoController(AppDbContext context) : ControllerBase
{
  // 获取所有任务
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        Console.WriteLine("test1！");
        return Ok(await context.TodoItems.ToListAsync());
    }

    // 创建任务
    [HttpPost]
    public async Task<IActionResult> Create(TodoItem item)
    {
        context.TodoItems.Add(item);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
    }
}