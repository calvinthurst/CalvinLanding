namespace CalvinLanding.Repositories;

public class ItemRepository
{
  private readonly IDbConnection _db;

  public ItemRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Item> Get()
  {
    string sql = "SELECT * FROM items";
    return _db.Query<Item>(sql).ToList();
  }

  public Item Get(int id)
  {
    string sql = @"SELECT 
        i.*,
        im.*
        FROM items i
        JOIN itemmodels im ON i.itemModel = im.id
        WHERE i.id = @id";
    return _db.Query<Item, ItemModel, Item>(sql, (item, itemModel) =>
    {
      item.itemSprite = itemModel;
      return item;
    }, new { id }, splitOn: "id").FirstOrDefault();
  }

  public Item Create(Item newItem)
  {
    string sql = @"
        INSERT INTO items
        (name, attack, gold, picture, description, itemModel)
        VALUES
        (@Name, @Attack, @Gold, @Picture, @Description, @ItemModel);
        SELECT LAST_INSERT_ID();";
    newItem.id = _db.ExecuteScalar<int>(sql, newItem);
    return newItem;
  }

  public Item Edit(Item editData)
  {
    string sql = @"
        UPDATE items
        SET
            name = @Name,
            attack = @Attack,
            gold = @Gold,
            picture = @Picture,
            description = @Description,
            itemModel = @ItemModel
        WHERE id = @Id;";
    _db.Execute(sql, editData);
    return editData;
  }

  public void Delete(int id)
  {
    string sql = "DELETE FROM items WHERE id = @id LIMIT 1";
    _db.Execute(sql, new { id });
  }
}
