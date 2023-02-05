namespace CalvinLanding.Models;

public class MonsterItems
{
  public int id { get; set; }
  public int monsterId { get; set; }
  public int itemId { get; set; }
  public int quantity { get; set; }
  public Monster monster { get; set; }
  public Item item { get; set; }
}
