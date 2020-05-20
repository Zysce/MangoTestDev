using System;
using System.Collections.Generic;
using System.Text;
using MangoTestDevWeb.Domain;
using Microsoft.AspNetCore.Identity;

namespace MangoTestDevWeb.Services
{
  public interface ITokenService
  {
    Response<JwtResult> GenerateToken(IdentityUser user);
  }
}
