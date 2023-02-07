namespace CalvinLanding.Repositories;

public class MonsterModelRepository
{
  private readonly IDbConnection _db;

  public MonsterModelRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<MonsterModel> Get()
  {
    string sql = "SELECT * FROM monsterModel";
    return _db.Query<MonsterModel>(sql).ToList();
  }

  public MonsterModel Get(int id)
  {
    string sql = "SELECT * FROM monsterModel WHERE id = @id";
    return _db.QueryFirstOrDefault<MonsterModel>(sql, new { id });
  }

  public MonsterModel Create(MonsterModel newItem)
  {
    string sql = @"
            INSERT INTO monsterModel
            (name, description, frontPicture, backPicture, leftPicture, rightPicture)
            VALUES
            (@Name, @Description, @FrontPicture, @BackPicture, @LeftPicture, @RightPicture);
            SELECT LAST_INSERT_ID();";
    int id = _db.ExecuteScalar<int>(sql, newItem);
    newItem.id = id;
    return newItem;
  }

  public bool Edit(MonsterModel editData)
  {
    string sql = @"
            UPDATE monsterModel
            SET
                name = @Name,
                description = @Description,
                frontPicture = @FrontPicture,
                backPicture = @BackPicture,
                leftPicture = @LeftPicture,
                rightPicture = @RightPicture
            WHERE id = @Id;";
    int affectedRows = _db.Execute(sql, editData);
    return affectedRows == 1;
  }

  public bool Delete(int id)
  {
    string sql = "DELETE FROM monsterModel WHERE id = @id LIMIT 1";
    int affectedRows = _db.Execute(sql, new { id });
    return affectedRows == 1;
  }

}
