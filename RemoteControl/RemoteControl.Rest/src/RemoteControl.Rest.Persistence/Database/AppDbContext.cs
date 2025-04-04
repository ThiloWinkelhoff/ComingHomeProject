using Microsoft.EntityFrameworkCore;
using RemoteControl.Rest.Persistence.Database.Models;

namespace RemoteControl.Rest.Persistence.Database;

public class AppDbContext : DbContext
{
    public DbSet<Device> Devices { get; set; }
    public DbSet<Script> Scripts { get; set; }
    public DbSet<DeviceScript> DeviceScripts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=your_server;Database=your_db;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeviceScript>()
            .HasKey(ds => new { ds.DeviceId, ds.ScriptId });

        modelBuilder.Entity<DeviceScript>()
            .HasOne(ds => ds.Device)
            .WithMany(d => d.DeviceScripts)
            .HasForeignKey(ds => ds.DeviceId);

        modelBuilder.Entity<DeviceScript>()
            .HasOne(ds => ds.Script)
            .WithMany(s => s.DeviceScripts)
            .HasForeignKey(ds => ds.ScriptId);
    }
}