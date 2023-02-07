namespace CalvinLanding.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MonsterController : ControllerBase
{
  private readonly MonsterService _monsterService;
  public MonsterController(MonsterService monsterService)
  {
    _monsterService = monsterService;
  }
  [HttpGet]
  public ActionResult<IEnumerable<Monster>> Get()
  {
    try
    {
      return Ok(_monsterService.Get());
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet("{id}")]
  public ActionResult<Monster> Get(int id)
  {
    try
    {
      return Ok(_monsterService.Get(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpPost]
  public ActionResult<Monster> Create([FromBody] Monster newMonster)
  {
    try
    {
      return Ok(_monsterService.Create(newMonster));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpPut("{id}")]
  public ActionResult<Monster> Edit([FromBody] Monster editData, int id)
  {
    try
    {
      editData.id = id;
      return Ok(_monsterService.Edit(editData));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpDelete("{id}")]
  public ActionResult<Monster> Delete(int id)
  {
    try
    {
      return Ok(_monsterService.Delete(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}

