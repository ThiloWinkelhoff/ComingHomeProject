using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl.Rest.Persistence;
internal class ComingHomeDbContext : DbContext
{
public DbSet<User> Users { get; set; }  // Example entity

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=YourDatabaseName;User Id=yourUsername;Password=yourPassword;TrustServerCertificate=True;");
}
}
