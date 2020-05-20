using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace MangoTestDevWeb.Services
{
  public class ClaimsBuilder : IClaimsBuilder
  {
    private readonly ILogger<ClaimsBuilder> _log;

    public ClaimsBuilder(ILogger<ClaimsBuilder> log)
    {
      _log = log;
    }

    public ClaimsIdentity Build(IdentityUser user)
    {

      var defaultClaims = new[]
      {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.NameIdentifier, user.Email),
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
      };

      LogClaims(user, defaultClaims);

      return new ClaimsIdentity(defaultClaims, "token");
    }

    private void LogClaims(IdentityUser user, IEnumerable<Claim> claims)
    {
      if (!_log.IsEnabled(LogLevel.Debug))
      {
        return;
      }

      var claimsStr = claims.Select(x => $"{x.Type} - {x.Value}");
      _log.LogDebug("User {0} claims:\n\n{1}", user.Email, string.Join('\n', claimsStr));
    }
  }
}
