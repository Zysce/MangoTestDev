using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace MangoTestDevWeb.Api
{
  public static class CorsConfiguration
  {
    public static IApplicationBuilder UseCors(this IApplicationBuilder app)
    {
      app.UseCors(x => x
          .WithOrigins("http://localhost:8080") // TODO add url in settings
            .AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader());

      return app;
    }
  }
}
