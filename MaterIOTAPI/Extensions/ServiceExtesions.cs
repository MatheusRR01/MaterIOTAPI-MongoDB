using MaterIOTAPI.Models;
using MaterIOTAPI.Repositories;
using MongoDB.Driver;

namespace MaterIOTAPI.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );
        });
    }

    public static void ConfigureMongoDBSettings(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<MongoDBSettings>(
            config.GetSection("MongoDBSettings")
        );

        services.AddSingleton<IMongoDatabase>(options =>
        {
            var settings = config.GetSection("MongoDBSettings").Get<MongoDBSettings>();
            var client = new MongoClient(settings.ConnectionString);
            return client.GetDatabase(settings.DatabaseName);
        });
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IClientRepository, ClientRepository>();
    }

}