using Microsoft.EntityFrameworkCore;
using RemoteControl.Rest.Persistence.Database.Models;

namespace RemoteControl.Rest.Persistence.Database;

/// <summary>
///     Database Connection for the application.
///     Configured in the application appsettings.json
///     under Connection Strings
/// </summary>
public class ApplicationDbContext : DbContext
{
    public DbSet<Device> Devices { get; set; }
    public DbSet<Script> Scripts { get; set; }
    public DbSet<DeviceScriptsMapping> DeviceScriptsMappings { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define the many-to-many relationship
        modelBuilder.Entity<DeviceScriptsMapping>()
            .HasKey(dm => new { dm.DeviceId, dm.ScriptId }); // Composite primary key

        modelBuilder.Entity<DeviceScriptsMapping>()
            .HasOne(dm => dm.Device)
            .WithMany(d => d.DeviceScriptsMappings)
            .HasForeignKey(dm => dm.DeviceId);

        modelBuilder.Entity<DeviceScriptsMapping>()
            .HasOne(dm => dm.Script)
            .WithMany(s => s.DeviceScriptsMappings)
            .HasForeignKey(dm => dm.ScriptId);
    }
}
