using System;
using System.Text;
using MangoTestDevWeb.Domain.Configuration;
using MangoTestDevWeb.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MangoTestDevWeb.Api
{
  public static class AuthenticationConfiguration
  {
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
    {
      services.AddIdentity<IdentityUser, IdentityRole>(opt =>
      {
        opt.Password.RequiredLength = 4;
        opt.Password.RequireDigit = false;
        opt.Password.RequireLowercase = true;
        opt.Password.RequireUppercase = true;
        opt.Password.RequireNonAlphanumeric = false;
        opt.SignIn.RequireConfirmedEmail = false;
        opt.SignIn.RequireConfirmedAccount = false;
      })
      .AddEntityFrameworkStores<ApplicationDbContext>()
      .AddDefaultTokenProviders();

      var auth = services.BuildServiceProvider().GetRequiredService<IOptions<Auth>>().Value;
      services
        .AddAuthentication(options =>
        {
          options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(opts =>
        {
          opts.SaveToken = true;
          opts.TokenValidationParameters = new TokenValidationParameters
          {
            ClockSkew = TimeSpan.Zero,
            RequireAudience = true,
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidAudiences = new[] { auth.Audience },
            ValidIssuer = auth.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(auth.Secret)),
            RequireExpirationTime = true
          };
        });
      services.AddAuthorization();

      return services;
    }
  }
}
