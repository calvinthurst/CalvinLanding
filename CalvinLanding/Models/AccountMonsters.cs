namespace CalvinLanding.Models;

public class AccountMonsters
{
  public int id { get; set; }
  public int accountId { get; set; }
  public int monsterId { get; set; }
  public Monster monster { get; set; }
  public Account account { get; set; }
}
