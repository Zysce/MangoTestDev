using System.Collections.Generic;
using System.Threading.Tasks;
using MangoTestDevWeb.Domain;

namespace MangoTestDevWeb.Infrastructure.Repositories
{
  public interface IItemRepository
  {
    Task<IEnumerable<Item>> GetAll();
    Task Add(Item item);
  }
}
