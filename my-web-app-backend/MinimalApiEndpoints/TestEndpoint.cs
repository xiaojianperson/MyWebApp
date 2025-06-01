using my_web_app_backend.Extensions;

namespace my_web_app_backend.MinimalApiEndpoints;

public class TestEndpoint : IMinimalApiEndpoint
{
    private static readonly List<int> _users = [];

    public void RegisterRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/MinimalApi/users");

        group.MapGet("", () => _users);
        group.MapGet("{id}", (int id) => _users.FirstOrDefault(u => u == id));
        group.MapPost("", (int user) => _users.Add(user));
    }
}