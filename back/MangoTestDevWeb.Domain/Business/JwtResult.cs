using System;

namespace MangoTestDevWeb.Domain
{
  public class JwtResult
  {
    public string AccessToken { get; set; }
    public DateTime Expires { get; set; }
  }
}
