using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MangoTestDevWeb.Domain.Configuration
{
  public class Auth
  {
    [Required]
    public string Audience { get; set; }
    [Required]
    public string Issuer { get; set; }
    [Required]
    public string Secret { get; set; }
    public int ExpiresInMinutes { get; set; } = 120;
  }
}
