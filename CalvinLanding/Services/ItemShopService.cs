namespace CalvinLanding.Services;

public class ItemShopService
{
  private readonly ItemShopRepository _repo;

  public ItemShopService(ItemShopRepository repo)
  {
    _repo = repo;
  }

  public List<ItemShop> Get()
  {
    return _repo.Get();
  }

  public ItemShop Get(int id)
  {
    ItemShop found = _repo.Get(id);
    if (found == null)
    {
      throw new Exception("Invalid Id");
    }
    return found;
  }

  public ItemShop Create(ItemShop newItem)
  {
    return _repo.Create(newItem);
  }

  public ItemShop Edit(ItemShop editData)
  {
    ItemShop original = Get(editData.id);
    original.itemId = editData.itemId != 0 ? editData.itemId : original.itemId;
    original.price = editData.price != 0 ? editData.price : original.price;
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
