using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DocuWikiExporter.Infrastructure.Persistence;

namespace DocuWikiExporter.Infrastructure;

/// <summary>Registriert die Infrastructure-Abhängigkeiten.</summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        // Die Connection String zeigt auf die bestehende SQLite-Datei.
        // Es wird bewusst keine Migration bzw. kein EnsureCreated aufgerufen.
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connectionString));

        return services;
    }
}
