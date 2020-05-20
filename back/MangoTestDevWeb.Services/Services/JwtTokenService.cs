using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MangoTestDevWeb.Domain;
using MangoTestDevWeb.Domain.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MangoTestDevWeb.Services
{
  public class JwtTokenService : ITokenService
  {
    private readonly IClaimsBuilder _claimsBuilder;
    private readonly Auth _config;

    public JwtTokenService(IClaimsBuilder claimsBuilder, IOptions<Auth> authConfig)
    {
      _config = authConfig.Value;
      _claimsBuilder = claimsBuilder;
    }

    public Response<JwtResult> GenerateToken(IdentityUser user)
    {
      if (user == null)
      {
        return new Response<JwtResult>();
      }

      var claims = _claimsBuilder.Build(user);

      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Secret));
      var now = DateTime.UtcNow;
      var expiration = TimeSpan.FromMinutes(_config.ExpiresInMinutes);
      var expirationDate = now.Add(expiration);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = claims,
        Expires = expirationDate,
        IssuedAt = now,
        Issuer = _config.Issuer, // TODO: use url of api instead
        Audience = _config.Audience, // TODO: use url from request instead
        SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature)
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);
      var jwtToken = tokenHandler.WriteToken(token);
      var tokenResult = new JwtResult
      {
        AccessToken = jwtToken,
        Expires = expirationDate
      };

      return new Response<JwtResult>(tokenResult);
    }
  }
}
