namespace CalvinLanding.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemShopController : ControllerBase
{
  private readonly ItemShopService _itemShopService;

  public ItemShopController(ItemShopService itemShopService)
  {
    _itemShopService = itemShopService;
  }

  [HttpGet]
  public ActionResult<List<ItemShop>> Get()
  {
    try
    {
      return Ok(_itemShopService.Get());
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<ItemShop> Get(int id)
  {
    try
    {
      return Ok(_itemShopService.Get(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<ItemShop> Create([FromBody] ItemShop newItem)
  {
    try
    {
      return Ok(_itemShopService.Create(newItem));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public ActionResult<ItemShop> Edit([FromBody] ItemShop editData, int id)
  {
    try
    {
      editData.id = id;
      return Ok(_itemShopService.Edit(editData));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  public ActionResult<string> Delete(int id)
  {
    try
    {
      return Ok(_itemShopService.Delete(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
