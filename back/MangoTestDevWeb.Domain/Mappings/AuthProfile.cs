using AutoMapper;
using MangoTestDevWeb.Domain.DataContract;

namespace MangoTestDevWeb.Domain.Mappings
{
  public class AuthProfile : Profile
  {
    public AuthProfile()
    {
      CreateMap<JwtResult, JwtResultDto>();
    }
  }
}
