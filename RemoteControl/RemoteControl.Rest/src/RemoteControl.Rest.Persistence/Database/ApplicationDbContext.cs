using Microsoft.EntityFrameworkCore;
using RemoteControl.Rest.Persistence.Database.Models;

namespace RemoteControl.Rest.Persistence.Database;

/// <summary>
///     Database context for the application.
///     Configured in the application's <c>appsettings.json</c> under Connection
///     Strings.
///     Provides access to the application’s data models, including devices,
///     scripts, and their mappings.
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    ///     Gets or sets the <see cref="DbSet{Device}" /> for devices in the
    ///     application.
    ///     This represents the collection of devices in the database.
    /// </summary>
    public DbSet<Device> Devices { get; set; }

    /// <summary>
    ///     Gets or sets the <see cref="DbSet{Script}" /> for scripts in the
    ///     application.
    ///     This represents the collection of scripts in the database.
    /// </summary>
    public DbSet<Script> Scripts { get; set; }

    /// <summary>
    ///     Gets or sets the <see cref="DbSet{DeviceScriptsMapping}" /> for
    ///     device-script mappings in the application.
    ///     This represents the collection of many-to-many mappings between devices and
    ///     scripts in the database.
    /// </summary>
    public DbSet<DeviceScriptsMapping> DeviceScriptsMappings { get; set; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ApplicationDbContext" />
    ///     class.
    ///     This constructor takes options for the <see cref="DbContext" />
    ///     configuration.
    /// </summary>
    /// <param name="options">
    ///     The <see cref="DbContextOptions{ApplicationDbContext}" />
    ///     used to configure the context.
    /// </param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    ///     Configures the <see cref="DbContext" /> to use lazy loading proxies.
    /// </summary>
    /// <param name="optionsBuilder">
    ///     The <see cref="DbContextOptionsBuilder" /> used to
    ///     configure the context.
    /// </param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies();
    }

    /// <summary>
    ///     Configures the model for the database context, including relationships and
    ///     constraints.
    ///     This method defines a many-to-many relationship between
    ///     <see cref="Device" /> and <see cref="Script" />
    ///     through the <see cref="DeviceScriptsMapping" /> entity.
    /// </summary>
    /// <param name="modelBuilder">
    ///     The <see cref="ModelBuilder" /> used to configure
    ///     the entity models.
    /// </param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define the many-to-many relationship between Device and Script
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