using System;

namespace MangoTestDevWeb.Domain.DataContract
{
  public class JwtResultDto
  {
    public string AccessToken { get; set; }
    public DateTime Expires { get; set; }
  }
}
