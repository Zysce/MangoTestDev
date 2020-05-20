using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MangoTestDevWeb.Domain.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MangoTestDevWeb.Api
{
  public static class SettingsConfiguration
  {
    public static IServiceCollection ConfigureAndValidate(this IServiceCollection services,
          IConfiguration config)
    {
      services
      .ConfigureAndValidate<Database>(config)
      .ConfigureAndValidate<Auth>(config);

      return services;
    }

    public static IServiceCollection ConfigureAndValidate<T>(this IServiceCollection services,
          IConfiguration config) where T : class
    {
      return services
        .Configure<T>(config.GetSection(typeof(T).Name))
        .PostConfigure<T>(settings =>
        {
          var context = new ValidationContext(settings, null, null);
          var results = new List<ValidationResult>();
          Validator.TryValidateObject(settings, context, results, true);

          var configErrors = results.Select(e => e.ErrorMessage).ToArray();
          if (configErrors.Any())
          {
            string aggrErrors = string.Join('\n', configErrors);
            var count = configErrors.Length;
            var configType = typeof(T).Name;
            throw new Exception($"Found {count} configuration error(s) in {configType}: \n{aggrErrors}");
          }
        });
    }
  }
}
