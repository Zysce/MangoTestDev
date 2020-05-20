using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MangoTestDevWeb.Domain.Configuration
{
  public class Database
  {
    [Required]
    public string Server { get; set; }
    [Required]
    public string Version { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string User { get; set; }
    [Required]
    public string Password { get; set; }
  }
}
