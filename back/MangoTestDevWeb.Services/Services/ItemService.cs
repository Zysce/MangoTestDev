using System.Collections.Generic;
using System.Threading.Tasks;
using MangoTestDevWeb.Domain;
using MangoTestDevWeb.Infrastructure.Repositories;

namespace MangoTestDevWeb.Services
{
  public class ItemService : IItemService
  {
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
      _itemRepository = itemRepository;
    }

    public Task Add(Item item)
    {
      return _itemRepository.Add(item);
    }

    public Task<IEnumerable<Item>> GetAll()
    {
      return _itemRepository.GetAll();
    }
  }
}
