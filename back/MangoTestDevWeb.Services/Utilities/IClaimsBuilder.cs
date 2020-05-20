using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace MangoTestDevWeb.Services
{
  public interface IClaimsBuilder
  {
    ClaimsIdentity Build(IdentityUser user);
  }
}
