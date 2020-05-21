using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MangoTestDevWeb.Api
{
  public static class CorsConfiguration
  {
    public static IServiceCollection AddCors(this IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy("AllowAll",
            builder =>
            {
              builder
                  .AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
            });
      });

      return services;
    }
  }
}
