namespace CalvinLanding.Services;

public class ItemModelService
{
  private readonly ItemModelRepository _repo;

  public ItemModelService(ItemModelRepository repo)
  {
    _repo = repo;
  }

  public List<ItemModel> Get()
  {
    return _repo.Get();
  }

  public ItemModel Get(int id)
  {
    ItemModel found = _repo.Get(id);
    if (found == null)
    {
      throw new Exception("Invalid Id");
    }
    return found;
  }

  public ItemModel Create(ItemModel newItem)
  {
    return _repo.Create(newItem);
  }

  public ItemModel Edit(ItemModel editData)
  {
    ItemModel original = Get(editData.id);
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
