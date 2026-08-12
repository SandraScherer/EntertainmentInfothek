using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DocuWikiExporter.Infrastructure.Persistence;

namespace DocuWikiExporter.Infrastructure;

/// <summary>Registriert Infrastructure-Dienste. Der Connection String kommt bewusst von außen.</summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite(connectionString);
            // Für eine produktive Bestandsdatenbank wird kein EnsureCreated/Migrate aufgerufen.
        });

        return services;
    }
}
