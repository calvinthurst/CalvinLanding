namespace CalvinLanding.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
  private readonly ProjectsService _projectsService;
  private readonly Auth0Provider _auth0Provider;

  public ProjectsController(ProjectsService projectsService, Auth0Provider auth0Provider)
  {
    _projectsService = projectsService;
    _auth0Provider = auth0Provider;
  }

  [HttpGet]
  public ActionResult<List<Project>> Get()
  {
    try
    {
      return Ok(_projectsService.Get());
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<Project> Get(int id)
  {
    try
    {
      return Ok(_projectsService.Get(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<Project> Create([FromBody] Project newItem)
  {
    try
    {
      return Ok(_projectsService.Create(newItem));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public ActionResult<Project> Edit([FromBody] Project editData, int id)
  {
    try
    {
      editData.id = id;
      return Ok(_projectsService.Edit(editData));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  public ActionResult<Project> Delete(int id)
  {
    try
    {
      return Ok(_projectsService.Delete(id));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


}
