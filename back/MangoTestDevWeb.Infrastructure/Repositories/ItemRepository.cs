using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MangoTestDevWeb.Domain;
using Microsoft.EntityFrameworkCore;

namespace MangoTestDevWeb.Infrastructure.Repositories
{
  public class ItemRepository : IItemRepository
  {
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public ItemRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public async Task Add(Item item)
    {
      var agg = _mapper.Map<ItemAggregate>(item);
      agg.Id = 0;

      await _dbContext.Items.AddAsync(agg);

      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Item>> GetAll()
    {
      var items = await _dbContext.Items.ToListAsync();

      return _mapper.Map<IEnumerable<Item>>(items);
    }
  }
}
