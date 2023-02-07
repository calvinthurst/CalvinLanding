namespace CalvinLanding.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MonsterModelController : ControllerBase
{
  private readonly MonsterModelService _monsterModelService;

  public MonsterModelController(MonsterModelService monsterModelService)
  {
    _monsterModelService = monsterModelService;
  }

  [HttpGet]
  public ActionResult<List<MonsterModel>> Get()
  {
    try
    {
      return Ok(_monsterModelService.Get());
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<MonsterModel> Get(int id)
  {
    try
    {
      return Ok(_monsterModelService.Get(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<MonsterModel> Create([FromBody] MonsterModel newItem)
  {
    try
    {
      return Ok(_monsterModelService.Create(newItem));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public ActionResult<MonsterModel> Edit([FromBody] MonsterModel editData, int id)
  {
    try
    {
      editData.id = id;
      return Ok(_monsterModelService.Edit(editData));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  public ActionResult<MonsterModel> Delete(int id)
  {
    try
    {
      return Ok(_monsterModelService.Delete(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}
