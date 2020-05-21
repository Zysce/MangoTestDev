using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MangoTestDevWeb.Domain;
using MangoTestDevWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MangoTestDevWeb.Api.Controllers
{
  [Authorize]
  [Consumes("application/json")]
  [Route("api/[controller]")]
  [ApiController]
  public class ItemController : ControllerBase
  {
    private readonly IItemService _itemService;
    private readonly IMapper _mapper;

    public ItemController(IItemService itemService, IMapper mapper)
    {
      _itemService = itemService;
      _mapper = mapper;
    }

    [HttpGet]
    [Route("")]
    [Produces(typeof(IEnumerable<ItemDto>))]
    public async Task<IActionResult> Get()
    {
      var items = await _itemService.GetAll();
      return Ok(_mapper.Map<IEnumerable<ItemDto>>(items));
    }

    [HttpPost]
    [Route("")]
    [Produces(typeof(IEnumerable<ItemDto>))]
    public async Task<IActionResult> Create([FromBody, Required] ItemDto item)
    {
      var itemBusiness = _mapper.Map<Item>(item);
      try
      {
        await _itemService.Add(itemBusiness);
        return NoContent();
      }
      catch (Exception)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }
  }
}
