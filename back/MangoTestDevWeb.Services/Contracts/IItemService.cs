using System.Collections.Generic;
using System.Threading.Tasks;
using MangoTestDevWeb.Domain;

namespace MangoTestDevWeb.Services
{
  public interface IItemService
  {
    Task<IEnumerable<Item>> GetAll();
    Task Add(Item item);
  }
}
