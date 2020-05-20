using System;
using MangoTestDevWeb.Domain.Configuration;
using MangoTestDevWeb.Infrastructure;
using MangoTestDevWeb.Infrastructure.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace MangoTestDevWeb.Api
{
  public static class DatabaseConfiguration
  {
    public static IServiceCollection AddEntityFramework(this IServiceCollection services)
    {
      var builder = services.BuildServiceProvider();
      var dbOptions = builder.GetRequiredService<IOptions<Database>>().Value;
      var connectionStringBuilder = builder.GetRequiredService<IConnectionStringBuilder>();
      var connectionString = connectionStringBuilder.Build(dbOptions);

      services.AddDbContext<ApplicationDbContext>(opts =>
      {
        opts
        .UseMySql(connectionString, mySqlOptions =>
                    mySqlOptions
                      .ServerVersion(new Version(dbOptions.Version), ServerType.MySql)
                      .CharSet(CharSet.Utf8Mb4)
                      )
        .EnableDetailedErrors();
      });

      return services;
    }

    public static IServiceCollection SeedData(this IServiceCollection services)
    {
      var provider = services.BuildServiceProvider();

      var dbContext = provider.GetRequiredService<ApplicationDbContext>();
      dbContext.Database.Migrate();

      var userManager = provider.GetRequiredService<UserManager<IdentityUser>>();

      if (userManager.FindByNameAsync("user").GetAwaiter().GetResult() == null)
      {
        var adminUser = new IdentityUser
        {
          UserName = "user",
          Email = "user@dev.com"
        };
        userManager.CreateAsync(adminUser, "User").GetAwaiter().GetResult();
      }

      return services;
    }
  }
}
