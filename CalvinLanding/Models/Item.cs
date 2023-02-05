namespace CalvinLanding.Models;

public class Item
{
  public int id { get; set; }
  public string name { get; set; }
  public int attack { get; set; }
  public int gold { get; set; }
  public string picture { get; set; }
  public string description { get; set; }
  public int itemModel { get; set; }
  public ItemModel itemSprite { get; set; }
}
