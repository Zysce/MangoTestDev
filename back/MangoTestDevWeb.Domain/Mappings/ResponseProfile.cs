using AutoMapper;

namespace MangoTestDevWeb.Domain.Mappings
{
  public class ResponseProfile : Profile
  {
    public ResponseProfile()
    {
      CreateMap(typeof(Response<>), typeof(ResponseDto<>));
    }
  }
}
