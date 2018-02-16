using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using TalaTimeTable.Api.Data;
using TalaTimeTable.Api.Data.Entities;
using TalaTimeTable.Api.Models;
using TalaTimeTable.Api.Models.CustomerDtos;
using TalaTimeTable.Api.Models.FileDto;
using TalaTimeTable.Api.Models.FolderDtos;
using TalaTimeTable.Api.Services;

namespace TalaTimeTable.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

      // Add application services.
      // services.AddScoped<ITalaTimeTableRepository, TalaTimeTableRepository>();

      services.AddScoped<ITalaRepository<TalaCustomer>, TalaCustomerRepository>();
      services.AddScoped<ITalaRepository<TalaFolder>, TalaFolderRepository>();
      services.AddScoped<ITalaRepository<TalaFile>, TalaFileRepository>();

      services.AddCors();
      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole();
      loggerFactory.AddDebug(LogLevel.Information);
      loggerFactory.AddNLog();
      
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler(appBuilder =>
        {
          appBuilder.Run(async context =>
          {
            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (exceptionHandlerFeature != null)
            {
              var logger = loggerFactory.CreateLogger("Global exception logger");
              logger.LogError(500, exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);
              logger.LogError(500, exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);
            }

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
          });
        });
      }

      app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

      app.UseStaticFiles();
      app.UseAuthentication();

      AutoMapper.Mapper.Initialize(cfg => {
        cfg.CreateMap<TalaCustomer, CustomerDto>();
        cfg.CreateMap<CustomerForCreationDto, TalaCustomer>();
        cfg.CreateMap<CustomerForUpdateDto, TalaCustomer>();
        cfg.CreateMap<TalaCustomer, CustomerForUpdateDto>();

        cfg.CreateMap<TalaFolder, FolderDto>();
        cfg.CreateMap<FolderForCreationDto, TalaFolder>();
        cfg.CreateMap<FolderForUpdateDto, TalaFolder>();
        cfg.CreateMap<TalaFolder, FolderForUpdateDto>();

        cfg.CreateMap<TalaFile, FileDto>();
        cfg.CreateMap<FileForCreationDto, TalaFile>();
        cfg.CreateMap<FileForUpdateDto, TalaFile>();
        cfg.CreateMap<TalaFile, FileForUpdateDto>();
      });

      app.UseMvc();
    }
  }
}
