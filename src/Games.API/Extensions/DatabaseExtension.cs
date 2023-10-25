using Games.API.Configurations;
using MongoDB.Driver;
using System.Text;

namespace Games.API.Extensions;

public static class DatabaseExtension
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConfiguration = new DatabaseConfiguration();

        configuration
            .GetSection("Database")
            .Bind(databaseConfiguration);

        string connectionString = BuildConnectionString(databaseConfiguration);

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseConfiguration.Database);

        services.AddSingleton(database);
    }

    private static string BuildConnectionString(DatabaseConfiguration databaseConfiguration)
    {
        StringBuilder sb = new(databaseConfiguration.ConnectionString);

        sb.Replace("{username}", databaseConfiguration.Username)
            .Replace("{password}", databaseConfiguration.Password);

        return sb.ToString();
    }
}
