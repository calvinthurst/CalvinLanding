namespace CalvinLanding.Models;

public class Monster
{

  public int id { get; set; }
  public string name { get; set; }
  public int health { get; set; }
  public int attack { get; set; }
  public int gold { get; set; }
  public string picture { get; set; }
  public string description { get; set; }
  public int monsterModel { get; set; }
  public MonsterModel monsterSprite { get; set; }
}


