namespace CalvinLanding.Services;

public class MonsterModelService
{
  private readonly MonsterModelRepository _repo;

  public MonsterModelService(MonsterModelRepository repo)
  {
    _repo = repo;
  }

  public List<MonsterModel> Get()
  {
    return _repo.Get();
  }

  public MonsterModel Get(int id)
  {
    MonsterModel found = _repo.Get(id);
    if (found == null)
    {
      throw new Exception("Invalid Id");
    }
    return found;
  }

  public MonsterModel Create(MonsterModel newItem)
  {
    return _repo.Create(newItem);
  }

  public MonsterModel Edit(MonsterModel editData)
  {
    MonsterModel original = Get(editData.id);
    original.name = editData.name != null ? editData.name : original.name;
    original.description = editData.description != null ? editData.description : original.description;
    original.frontPicture = editData.frontPicture != null ? editData.frontPicture : original.frontPicture;
    original.backPicture = editData.backPicture != null ? editData.backPicture : original.backPicture;
    original.leftPicture = editData.leftPicture != null ? editData.leftPicture : original.leftPicture;
    original.rightPicture = editData.rightPicture != null ? editData.rightPicture : original.rightPicture;
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
