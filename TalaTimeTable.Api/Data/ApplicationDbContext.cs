using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TalaTimeTable.Api.Data.Entities;
using TalaTimeTable.Api.Models;

namespace TalaTimeTable.Api.Data
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<TalaCustomer> Customers { get; set; }
    public DbSet<TalaFolder> Folders { get; set; }
    public DbSet<TalaFile> Files { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      // Customize the ASP.NET Identity model and override the defaults if needed.
      // For example, you can rename the ASP.NET Identity table names and more.
      // Add your customizations after calling base.OnModelCreating(builder);
    }
  }
}
