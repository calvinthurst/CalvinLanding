namespace CalvinLanding.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MonsterItemsController : ControllerBase
{
  private readonly MonsterItemsService _monsterItemsService;

  public MonsterItemsController(MonsterItemsService monsterItemsService)
  {
    _monsterItemsService = monsterItemsService;
  }

  [HttpGet]
  public ActionResult<List<MonsterItems>> Get()
  {
    try
    {
      return Ok(_monsterItemsService.Get());
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<MonsterItems> Get(int id)
  {
    try
    {
      return Ok(_monsterItemsService.Get(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<MonsterItems> Create([FromBody] MonsterItems newItem)
  {
    try
    {
      return Ok(_monsterItemsService.Create(newItem));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public ActionResult<MonsterItems> Edit([FromBody] MonsterItems editData, int id)
  {
    try
    {
      editData.id = id;
      return Ok(_monsterItemsService.Edit(editData));
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
      return Ok(_monsterItemsService.Delete(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
