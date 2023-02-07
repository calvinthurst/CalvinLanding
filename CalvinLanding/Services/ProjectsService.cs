namespace CalvinLanding.Services;

public class ProjectsService
{
  private readonly ProjectsRepository _repo;

  public ProjectsService(ProjectsRepository repo)
  {
    _repo = repo;
  }

  public List<Project> Get()
  {
    return _repo.Get();
  }

  public Project Get(int id)
  {
    Project found = _repo.Get(id);
    if (found == null)
    {
      throw new Exception("Invalid Id");
    }
    return found;
  }

  public Project Create(Project newItem)
  {
    return _repo.Create(newItem);
  }

  public Project Edit(Project editData)
  {
    Project original = Get(editData.id);
    original.name = editData.name != null ? editData.name : original.name;
    original.description = editData.description != null ? editData.description : original.description;
    original.picture = editData.picture != null ? editData.picture : original.picture;
    original.gitHubUrl = editData.gitHubUrl != null ? editData.gitHubUrl : original.gitHubUrl;
    original.deployedUrl = editData.deployedUrl != null ? editData.deployedUrl : original.deployedUrl;
    if (_repo.Edit(original))
    {
      return original;
    }
    throw new Exception("Something went wrong");
  }

  public string Delete(int id)
  {
    if (_repo.Delete(id))
    {
      return "Successfully Deleted";
    }
    throw new Exception("Something went wrong");
  }
}
