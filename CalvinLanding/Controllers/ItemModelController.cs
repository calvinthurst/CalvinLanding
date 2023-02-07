namespace CalvinLanding.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemModelController : ControllerBase
{
  private readonly ItemModelService _itemModelService;

  public ItemModelController(ItemModelService itemModelService)
  {
    _itemModelService = itemModelService;
  }

  [HttpGet]
  public ActionResult<List<ItemModel>> Get()
  {
    try
    {
      return Ok(_itemModelService.Get());
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<ItemModel> Get(int id)
  {
    try
    {
      return Ok(_itemModelService.Get(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<ItemModel> Create([FromBody] ItemModel newItem)
  {
    try
    {
      return Ok(_itemModelService.Create(newItem));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]

  public ActionResult<ItemModel> Edit([FromBody] ItemModel editData, int id)
  {
    try
    {
      editData.id = id;
      return Ok(_itemModelService.Edit(editData));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  public ActionResult<ItemModel> Delete(int id)
  {
    try
    {
      return Ok(_itemModelService.Delete(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}
