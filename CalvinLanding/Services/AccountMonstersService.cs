namespace CalvinLanding.Services;

public class AccountMonstersService
{
  private readonly AccountMonsterRepository _repo;

  public AccountMonstersService(AccountMonsterRepository repo)
  {
    _repo = repo;
  }

  public List<AccountMonsters> Get()
  {
    return _repo.Get();
  }

  public AccountMonsters Get(int id)
  {
    AccountMonsters found = _repo.Get(id);
    if (found == null)
    {
      throw new Exception("Invalid Id");
    }
    return found;
  }

  public AccountMonsters Create(AccountMonsters newItem)
  {
    return _repo.Create(newItem);
  }

  public AccountMonsters Edit(AccountMonsters editData)
  {
    AccountMonsters original = Get(editData.id);
    original.accountId = editData.accountId != 0 ? editData.accountId : original.accountId;
    original.monsterId = editData.monsterId != 0 ? editData.monsterId : original.monsterId;
    _repo.Edit(original);
    if (original != null)
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
