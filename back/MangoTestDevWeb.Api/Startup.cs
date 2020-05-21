using System.Reflection;
using AutoMapper;
using MangoTestDevWeb.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace MangoTestDevWeb.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    private IWebHostEnvironment Environment { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services
        .AddAutoMapper(typeof(IAggregateRoot).GetTypeInfo().Assembly)
        .ConfigureAndValidate(Configuration)
        .AddCors()
        .AddRequiredServices()
        .AddEntityFramework();

      services.AddControllers();

      services
       .AddJwtAuthentication();

      services
        .AddLogging(l =>
        {
          l
            .ClearProviders()
            .AddConsole()
            .AddNLog();
          if (Environment != null && Environment.IsDevelopment())
          {
            l.AddDebug();
          }
        });

      //services.SeedData();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseCors();
      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller}/{action}/{id?}");
      });
    }
  }
}
