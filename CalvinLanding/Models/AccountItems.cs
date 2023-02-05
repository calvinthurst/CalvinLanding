namespace CalvinLanding.Models;

public class AccountItems
{
  public int id { get; set; }
  public int accountId { get; set; }
  public int itemId { get; set; }
  public int quantity { get; set; }
  public Item item { get; set; }
}
