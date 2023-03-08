namespace CalvinLanding.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountItemController : ControllerBase
{
  private readonly AccountItemService _accountItemService;
  private readonly Auth0Provider _auth0Provider;

  public AccountItemController(AccountItemService accountItemService, Auth0Provider auth0Provider)
  {
    _accountItemService = accountItemService;
    _auth0Provider = auth0Provider;
  }

  [HttpGet]
  public ActionResult<List<AccountItems>> Get()
  {
    try
    {
      return Ok(_accountItemService.Get());
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet("user")]
  [Authorize]
  public async Task<ActionResult<List<AccountItems>>> GetAccountItems()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountItemService.GetAccountItems(userInfo.Id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<AccountItems> Get(int id)
  {
    try
    {
      return Ok(_accountItemService.Get(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<AccountItems>> Create([FromBody] AccountItems newItem)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountItemService.Create(newItem, userInfo.Id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]

  public ActionResult<AccountItems> Edit([FromBody] AccountItems editData, int id)
  {
    try
    {
      editData.id = id;
      return Ok(_accountItemService.Edit(editData, id));
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
      return Ok(_accountItemService.Delete(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
