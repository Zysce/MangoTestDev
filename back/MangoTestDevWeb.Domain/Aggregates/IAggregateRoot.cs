using System;
using System.Collections.Generic;
using System.Text;

namespace MangoTestDevWeb.Domain
{
  public interface IAggregateRoot
  {
    int Id { get; set; }
  }
}
