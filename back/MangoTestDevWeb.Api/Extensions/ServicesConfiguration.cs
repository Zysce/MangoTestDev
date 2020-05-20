﻿using MangoTestDevWeb.Infrastructure.Utilities;
using MangoTestDevWeb.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MangoTestDevWeb.Api
{
  public static class ServicesConfiguration
  {
    public static IServiceCollection AddRequiredServices(this IServiceCollection services)
    {
      services.AddSingleton<ITokenService, JwtTokenService>();
      services.AddSingleton<IConnectionStringBuilder, MySqlConnectionStringBuilder>();
      services.AddSingleton<IClaimsBuilder, ClaimsBuilder>();
      services.AddScoped<IAuthenticationService, AuthenticationService>();

      return services;
    }
  }
}
