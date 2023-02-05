namespace CalvinLanding.Repositories;

public class MonsterItemsRepository
{
  private readonly IDbConnection _db;

  public MonsterItemsRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<MonsterItems> Get()
  {
    string sql = "SELECT * FROM monsterItems";
    return _db.Query<MonsterItems>(sql).ToList();
  }

  public MonsterItems Get(int id)
  {
    string sql = "SELECT * FROM monsterItems WHERE id = @id";
    return _db.QueryFirstOrDefault<MonsterItems>(sql, new { id });
  }

  public MonsterItems Create(MonsterItems newItem)
  {
    string sql = @"
        INSERT INTO monsterItems
        (monsterId, itemId, quantity)
        VALUES
        (@MonsterId, @ItemId, @Quantity);
        SELECT LAST_INSERT_ID();";
    int id = _db.ExecuteScalar<int>(sql, newItem);
    newItem.id = id;
    return newItem;
  }

  public bool Edit(MonsterItems editData)
  {
    string sql = @"
        UPDATE monsterItems
        SET
            monsterId = @MonsterId,
            itemId = @ItemId,
            quantity = @Quantity
        WHERE id = @Id;";
    int affectedRows = _db.Execute(sql, editData);
    return affectedRows == 1;
  }

  public bool Delete(int id)
  {
    string sql = "DELETE FROM monsterItems WHERE id = @id LIMIT 1";
    int affectedRows = _db.Execute(sql, new { id });
    return affectedRows == 1;
  }

}
