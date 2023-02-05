namespace CalvinLanding.Services;

public class AccountItemService
{
  private readonly AccountItemRepository _repo;
  private readonly AccountService _accountService;
  private readonly ItemService _itemService;

  public AccountItemService(AccountItemRepository repo, AccountService accountService, ItemService itemService)
  {
    _repo = repo;
    _accountService = accountService;
    _itemService = itemService;
  }

  public List<AccountItems> Get()
  {
    return _repo.Get();
  }

  public AccountItems Get(int id)
  {
    AccountItems found = _repo.Get(id);
    if (found == null)
    {
      throw new Exception("Invalid Id");
    }
    return found;
  }
  public List<AccountItems> GetAccountItems(string accountId)
  {
    return _repo.GetByAccountId(accountId);
  }

  public AccountItems Create(AccountItems newItem, string accountId)
  {
    Account user = _accountService.GetAccount(accountId);
    Item item = _itemService.Get(newItem.itemId);
    if (user.gold! >= item.gold)
    {
      throw new Exception("Not Enough gold");
    }
    user.gold -= item.gold;
    Account profile = _accountService.Edit(user, accountId);
    newItem.accountId = accountId;
    int id = _repo.Create(newItem);
    newItem.id = id;
    return newItem;
  }

  public AccountItems Edit(AccountItems editData, int id)
  {
    AccountItems original = Get(id);
    original.accountId = editData.accountId;
    original.itemId = editData.itemId;
    original.quantity = editData.quantity;
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
