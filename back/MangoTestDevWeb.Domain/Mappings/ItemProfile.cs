using System;
using AutoMapper;

namespace MangoTestDevWeb.Domain.Mappings
{
  public class ItemProfile : Profile
  {
    public ItemProfile()
    {
      CreateMap<ItemAggregate, Item>().ReverseMap();
      CreateMap<Item, ItemDto>()
        .ForMember(i => i.Image, member => member.MapFrom(x => Convert.ToBase64String(x.Image)));
      CreateMap<ItemDto, Item>()
        .ForMember(
        i => i.Image,
        member =>
        {
          member.PreCondition(c => !string.IsNullOrWhiteSpace(c.Image));
          member.MapFrom(x => Convert.FromBase64String(x.Image.Replace("data:image/jpeg;base64,", "")));
        });
    }
  }
}
