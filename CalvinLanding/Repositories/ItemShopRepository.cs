namespace CalvinLanding.Repositories;

public class ItemShopRepository
{
  private readonly IDbConnection _db;

  public ItemShopRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<ItemShop> Get()
  {
    string sql = "SELECT * FROM itemShop";
    return _db.Query<ItemShop>(sql).ToList();
  }

  public ItemShop Get(int id)
  {
    string sql = "SELECT * FROM itemShop WHERE id = @id";
    return _db.QueryFirstOrDefault<ItemShop>(sql, new { id });
  }

  public ItemShop Create(ItemShop newItem)
  {
    string sql = @"
            INSERT INTO itemShop
            (itemId, price)
            VALUES
            (@ItemId, @Price);
            SELECT LAST_INSERT_ID();";
    int id = _db.ExecuteScalar<int>(sql, newItem);
    newItem.id = id;
    return newItem;
  }

  public bool Edit(ItemShop editData)
  {
    string sql = @"
            UPDATE itemShop
            SET
                itemId = @ItemId,
                price = @Price
            WHERE id = @Id;";
    int affectedRows = _db.Execute(sql, editData);
    return affectedRows == 1;
  }

  public bool Delete(int id)
  {
    string sql = "DELETE FROM itemShop WHERE id = @id LIMIT 1";
    int affectedRows = _db.Execute(sql, new { id });
    return affectedRows == 1;
  }

}
