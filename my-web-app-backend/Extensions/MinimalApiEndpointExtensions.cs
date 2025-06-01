using System.Reflection;

namespace my_web_app_backend.Extensions;

public static class MinimalApiEndpointExtensions
{
    public static IServiceCollection RegisterApiEndpoints(
        this IServiceCollection services,
        params Assembly[] assemblies)
    {
        // 自动注册所有实现了IApiEndpoint的服务
        var endpointTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => typeof(IMinimalApiEndpoint).IsAssignableFrom(t) && !t.IsInterface);

        foreach (var type in endpointTypes)
        {
            services.AddScoped(typeof(IMinimalApiEndpoint), type);
        }

        return services;
    }

    public static WebApplication MapApiEndpoints(this WebApplication app)
    {
        // 从DI容器获取所有端点实例并注册路由
        using var scope = app.Services.CreateScope();
        var endpoints = scope.ServiceProvider.GetServices<IMinimalApiEndpoint>();

        foreach (var endpoint in endpoints)
        {
            endpoint.RegisterRoutes(app);
        }

        return app;
    }
}

public interface IMinimalApiEndpoint
{
    void RegisterRoutes(IEndpointRouteBuilder app);
}