using Games.API.Repositories;

namespace Games.API.Extensions;

public static class ServicesExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IGameRepository, GameRepository>();
    }
}
