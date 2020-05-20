using System.Threading.Tasks;
using MangoTestDevWeb.Domain;

namespace MangoTestDevWeb.Services
{
  public interface IAuthenticationService
  {
    Task<Response<JwtResult>> LoginAsync(string username, string password);
  }
}
