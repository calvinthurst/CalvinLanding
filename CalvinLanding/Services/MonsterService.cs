namespace CalvinLanding.Services;

public class MonsterService
{
  private readonly MonsterRepository _repo;

  public MonsterService(MonsterRepository repo)
  {
    _repo = repo;
  }

  internal IEnumerable<Monster> Get()
  {
    return _repo.Get();
  }

  internal Monster Get(int id)
  {
    Monster monster = _repo.GetById(id);
    if (monster == null)
    {
      throw new Exception("Invalid Id");
    }
    return monster;
  }

  internal Monster Create(Monster newMonster)
  {
    return _repo.Create(newMonster);
  }

  internal Monster Edit(Monster editData)
  {
    Monster original = Get(editData.id);
    original.name = editData.name.Length > 0 ? editData.name : original.name;
    original.health = editData.health > 0 ? editData.health : original.health;
    original.attack = editData.attack > 0 ? editData.attack : original.attack;
    original.gold = editData.gold > 0 ? editData.gold : original.gold;
    original.picture = editData.picture.Length > 0 ? editData.picture : original.picture;
    original.description = editData.description.Length > 0 ? editData.description : original.description;
    original.isBoss = editData.isBoss;
    original.monsterModel = editData.monsterModel > 0 ? editData.monsterModel : original.monsterModel;
    return _repo.Edit(original);
  }
  internal string Delete(int id)
  {
    Monster original = Get(id);
    _repo.Delete(original);
    return "Successfully Deleted";
  }
}
