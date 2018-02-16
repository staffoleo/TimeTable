using Microsoft.EntityFrameworkCore;
using TalaTimeTable.Api.Data;

namespace TalaTimeTable.Api.Test.Services
{
  public class TestHelper
  {
    public static ApplicationDbContext CreateDbContext()
    {
      var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
      builder.UseInMemoryDatabase("customer");
      var options = builder.Options;
      ApplicationDbContext dbContext = new ApplicationDbContext(options);
      dbContext.Database.EnsureDeleted();
      dbContext.Database.EnsureCreated();
      return dbContext;
    }
  }
}