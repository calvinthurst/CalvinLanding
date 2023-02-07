namespace CalvinLanding.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountMonsterController : ControllerBase
{
  private readonly AccountMonstersService _accountMonsterService;
  private readonly Auth0Provider _auth0Provider;
  public AccountMonsterController(AccountMonstersService accountMonsterService, Auth0Provider auth0Provider)
  {
    _accountMonsterService = accountMonsterService;
    _auth0Provider = auth0Provider;
  }

  [HttpGet]
  public ActionResult<List<AccountMonsters>> Get()
  {
    try
    {
      return Ok(_accountMonsterService.Get());
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<AccountMonsters> Get(int id)
  {
    try
    {
      return Ok(_accountMonsterService.Get(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<AccountMonsters> Create([FromBody] AccountMonsters newItem)
  {
    try
    {
      return Ok(_accountMonsterService.Create(newItem));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public ActionResult<AccountMonsters> Edit([FromBody] AccountMonsters editData, int id)
  {
    try
    {
      editData.id = id;
      return Ok(_accountMonsterService.Edit(editData));
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
      return Ok(_accountMonsterService.Delete(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}
