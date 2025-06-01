using my_web_app_backend.Extensions;
using my_web_app_backend.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 添加服务到容器
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddControllers();

// 正确配置 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "API 测试"
    });
});

// 自动注册所有在程序集中实现的端点
builder.Services.RegisterApiEndpoints(typeof(Program).Assembly);

var app = builder.Build();

// 配置 HTTP 请求管道
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        c.RoutePrefix = "swagger"; // 设置 Swagger UI 的访问路径
    });
}

app.UseHttpsRedirection();

// 正确的中间件顺序
app.UseRouting();

// 启用授权
// app.UseAuthorization();

// 映射端点
app.MapControllers();
app.MapApiEndpoints();

app.Run();