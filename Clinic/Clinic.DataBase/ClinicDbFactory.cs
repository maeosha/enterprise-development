using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Clinic.DataBase;

/// <summary>
/// Factory used at design-time to create instances of <see cref="ClinicDbContext"/>.
/// This is used by EF Core tools (migrations, scaffolding) to create a context.
/// </summary>
public class ClinicDbFactory : IDesignTimeDbContextFactory<ClinicDbContext>
{

    /// <summary>
    /// Creates a new <see cref="ClinicDbContext"/> for design-time operations.
    /// </summary>
    /// <param name="args">Command-line arguments (unused).</param>
    /// <returns>A configured <see cref="ClinicDbContext"/> instance.</returns>
    public ClinicDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var connectionString = configuration.GetConnectionString("ClinicDb");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'ClinicDb' not found.");
        }

        var optionsBuilder = new DbContextOptionsBuilder<ClinicDbContext>();
        optionsBuilder.UseNpgsql(
            connectionString
        );

        return new ClinicDbContext(optionsBuilder.Options);
    }

}