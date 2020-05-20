using System;
using System.Collections.Generic;
using System.Text;
using MangoTestDevWeb.Domain.Configuration;
using Microsoft.Extensions.Logging;

namespace MangoTestDevWeb.Infrastructure.Utilities
{
  public class MySqlConnectionStringBuilder : IConnectionStringBuilder
  {
    private readonly ILogger<MySqlConnectionStringBuilder> _log;

    public MySqlConnectionStringBuilder()
    { }

    public MySqlConnectionStringBuilder(ILogger<MySqlConnectionStringBuilder> log)
    {
      _log = log;
    }

    public string Build(Database dbOptions)
    {
      var builder = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder
      {
        Server = dbOptions.Server,
        Database = dbOptions.Name,
        UserID = dbOptions.User,
        Password = dbOptions.Password,
        PersistSecurityInfo = true,
        ConnectionTimeout = 30,
        DefaultCommandTimeout = 30
      };

      _log?.LogInformation($"Building mysql connection string for Server={dbOptions.Server}, Version={dbOptions.Version} Database={dbOptions.Name}, User={dbOptions.User}");
      return builder.ToString();
    }
  }
}
