using System;
using System.Collections.Generic;
using System.Text;
using MangoTestDevWeb.Domain.Configuration;

namespace MangoTestDevWeb.Infrastructure.Utilities
{
  public interface IConnectionStringBuilder
  {
    string Build(Database databaseOptions);
  }
}
