namespace CalvinLanding.Services;

public class MonsterItemsService
{
  private readonly MonsterItemsRepository _repo;

  public MonsterItemsService(MonsterItemsRepository repo)
  {
    _repo = repo;
  }

  public List<MonsterItems> Get()
  {
    return _repo.Get();
  }

  public MonsterItems Get(int id)
  {
    MonsterItems found = _repo.Get(id);
    if (found == null)
    {
      throw new Exception("Invalid Id");
    }
    return found;
  }

  public MonsterItems Create(MonsterItems newItem)
  {
    return _repo.Create(newItem);
  }

  public MonsterItems Edit(MonsterItems editData)
  {
    MonsterItems original = Get(editData.id);
    original.monsterId = editData.monsterId != 0 ? editData.monsterId : original.monsterId;
    original.itemId = editData.itemId != 0 ? editData.itemId : original.itemId;
    original.quantity = editData.quantity != 0 ? editData.quantity : original.quantity;
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
