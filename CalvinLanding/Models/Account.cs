namespace CalvinLanding.Models;

public class Account
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Picture { get; set; }
  public string savePage { get; set; }
  public string savePageTitle { get; set; }
  public int gold { get; set; }
  public int health { get; set; }
  public int attack { get; set; }
  public int lives { get; set; }
  public int characterModel { get; set; }
  public PlayerModel characterSprite { get; set; }

}