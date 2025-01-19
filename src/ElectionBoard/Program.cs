using ElectionBoard.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDbContext(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureDbContext(this  IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ElectionDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(ElectionDbContext.ConnectionStringName));
        });

        return services;
    }
}
