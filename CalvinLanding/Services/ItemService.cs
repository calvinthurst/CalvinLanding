namespace CalvinLanding.Services;

public class ItemService
{

  private readonly ItemRepository _repo;

  public ItemService(ItemRepository repo)
  {
    _repo = repo;
  }

  public List<Item> Get()
  {
    return _repo.Get();
  }

  public Item Get(int id)
  {
    return _repo.Get(id);
  }

  public Item Create(Item newItem)
  {
    return _repo.Create(newItem);
  }

  public Item Edit(Item editData, int id)
  {
    Item original = Get(id);
    original.name = editData.name != null ? editData.name : original.name;
    original.description = editData.description != null ? editData.description : original.description;
    original.gold = editData.gold > 0 ? editData.gold : original.gold;
    original.attack = editData.attack > 0 ? editData.attack : original.attack;
    original.picture = editData.picture != null ? editData.picture : original.picture;
    original.itemModel = editData.itemModel > 0 ? editData.itemModel : original.itemModel;
    return _repo.Edit(original);
  }

  public string Delete(int id)
  {
    _repo.Delete(id);
    return "Successfully Deleted";
  }
}
