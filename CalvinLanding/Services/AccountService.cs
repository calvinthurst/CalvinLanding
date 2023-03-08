namespace CalvinLanding.Services;

public class AccountService
{
  private readonly AccountsRepository _repo;

  public AccountService(AccountsRepository repo)
  {
    _repo = repo;
  }

  internal Account GetProfileByEmail(string email)
  {
    return _repo.GetByEmail(email);
  }

  internal Account GetOrCreateProfile(Account userInfo)
  {
    Account profile = _repo.GetById(userInfo.Id);
    if (profile == null)
    {
      return _repo.Create(userInfo);
    }
    return profile;
  }
  internal Account GetAccount(string accountId)
  {
    Account profile = _repo.GetById(accountId);
    if (profile == null)
    {
      throw new Exception("No account at that id");
    }
    return profile;
  }

  internal Account Edit(Account editData, string userId)
  {
    Account original = GetProfileByEmail(userId);
    original.Name = editData.Name.Length > 0 ? editData.Name : original.Name;
    original.Picture = editData.Picture.Length > 0 ? editData.Picture : original.Picture;
    original.Email = editData.Email.Length > 0 ? editData.Email : original.Email;
    original.savePage = editData.savePage.Length > 0 ? editData.savePage : original.savePage;
    original.savePageTitle = editData.savePageTitle.Length > 0 ? editData.savePageTitle : original.savePageTitle;
    original.gold = editData.gold > 0 ? editData.gold : original.gold;
    original.health = editData.health > 0 ? editData.health : original.health;
    original.attack = editData.attack > 0 ? editData.attack : original.attack;
    original.lives = editData.lives > 0 ? editData.lives : original.lives;
    original.characterModel = editData.characterModel > 0 ? editData.characterModel : original.characterModel;
    return _repo.Edit(original);
  }

}
