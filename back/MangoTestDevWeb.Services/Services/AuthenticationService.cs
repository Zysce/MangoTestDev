using System.Threading.Tasks;
using MangoTestDevWeb.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace MangoTestDevWeb.Services
{
  public class AuthenticationService : IAuthenticationService
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly ILogger<AuthenticationService> _log;

    public AuthenticationService(
      UserManager<IdentityUser> userManager,
      SignInManager<IdentityUser> signInManager,
      ITokenService tokenService,
      ILogger<AuthenticationService> log)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _tokenService = tokenService;
      _log = log;
    }

    public async Task<Response<JwtResult>> LoginAsync(string username, string password)
    {
      _log.LogInformation("Trying to log as {0}", username);

      var user = await _userManager.FindByNameAsync(username);
      if (user == null)
      {
        _log.LogInformation("User {0} not found", username);
        return new Response<JwtResult>();
      }

      var result = await _signInManager.PasswordSignInAsync(user, password, true, true);

      if (!result.Succeeded)
      {
        _log.LogInformation("User {0} password invalid", username);
        return new Response<JwtResult>();
      }

      _log.LogInformation("User {0} login successful", username);

      _log.LogInformation("Generating jwt for {0}", username);

      return _tokenService.GenerateToken(user);
    }

  }
}
