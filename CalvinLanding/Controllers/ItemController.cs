namespace CalvinLanding.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
  private readonly ItemService _itemService;

  public ItemController(ItemService itemService)
  {
    _itemService = itemService;
  }

  [HttpGet]
  public ActionResult<List<Item>> Get()
  {
    try
    {
      return Ok(_itemService.Get());
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<Item> Get(int id)
  {
    try
    {
      return Ok(_itemService.Get(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<Item> Create([FromBody] Item newItem)
  {
    try
    {
      return Ok(_itemService.Create(newItem));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public ActionResult<Item> Edit([FromBody] Item editData, int id)
  {
    try
    {
      editData.id = id;
      return Ok(_itemService.Edit(editData, id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  public ActionResult<Item> Delete(int id)
  {
    try
    {
      return Ok(_itemService.Delete(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
