using AutoMapper;

namespace MangoTestDevWeb.Domain.Mappings
{
  public class ItemProfile : Profile
  {
    public ItemProfile()
    {
      CreateMap<ItemAggregate, Item>().ReverseMap();
      CreateMap<Item, ItemDto>().ReverseMap();
    }
  }
}
