namespace CalvinLanding.Models;

public class ItemShop
{
  public int id { get; set; }
  public string name { get; set; }
  public string description { get; set; }
  public int itemId { get; set; }
  public int price { get; set; }
  public int playerModelId { get; set; }
  public PlayerModel playerModel { get; set; }
  public Item item { get; set; }

}
