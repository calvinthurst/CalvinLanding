namespace CalvinLanding.Repositories;

public class ItemModelRepository
{
  private readonly IDbConnection _db;

  public ItemModelRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<ItemModel> Get()
  {
    string sql = "SELECT * FROM itemModel";
    return _db.Query<ItemModel>(sql).ToList();
  }

  public ItemModel Get(int id)
  {
    string sql = "SELECT * FROM itemModel WHERE id = @id";
    return _db.QueryFirstOrDefault<ItemModel>(sql, new { id });
  }

  public ItemModel Create(ItemModel newItem)
  {
    string sql = @"
            INSERT INTO itemModel
            (name, description, frontPicture, backPicture, leftPicture, rightPicture)
            VALUES
            (@Name, @Description, @frontPicture, @backPicture, @leftPicture, @rightPicture);
            SELECT LAST_INSERT_ID();";
    int id = _db.ExecuteScalar<int>(sql, newItem);
    newItem.id = id;
    return newItem;
  }

  public bool Edit(ItemModel editData)
  {
    string sql = @"
            UPDATE itemModel
            SET
                name = @Name,
                description = @Description,
                type = @Type,
                rarity = @Rarity,
                value = @Value,
                attack = @Attack,
                defense = @Defense,
                health = @Health,
                mana = @Mana,
                speed = @Speed,
                strength = @Strength,
                dexterity = @Dexterity,
                intelligence = @Intelligence,
                wisdom = @Wisdom,
                charisma = @Charisma,
                luck = @Luck,
                image = @Image
            WHERE id = @Id;";
    int affectedRows = _db.Execute(sql, editData);
    return affectedRows == 1;
  }

  public bool Delete(int id)
  {
    string sql = "DELETE FROM itemModel WHERE id = @id LIMIT 1";
    int affectedRows = _db.Execute(sql, new { id });
    return affectedRows == 1;
  }

}
