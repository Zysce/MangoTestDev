using System;
using System.Collections.Generic;
using System.Text;

namespace MangoTestDevWeb.Domain.Aggregates
{
  public interface IAggregateRoot
  {
    int Id { get; set; }
  }
}
