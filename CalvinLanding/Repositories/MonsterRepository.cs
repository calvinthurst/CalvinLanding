namespace CalvinLanding.Repositories;

public class MonsterRepository
{
  private readonly IDbConnection _db;

  public MonsterRepository(IDbConnection db)
  {
    _db = db;
  }

  internal IEnumerable<Monster> Get()
  {
    string sql = @"SELECT 
    m.*,
    mm.*
    FROM monsters m
    JOIN monsterModels mm ON m.monsterModel = mm.id
    ";
    return _db.Query<Monster>(sql);
  }

  internal Monster GetById(int id)
  {
    string sql = @"SELECT
    m.*,
    mm.*
    FROM monsters m
    JOIN monsterModels mm ON m.monsterModel = mm.id
    WHERE m.id = @id
    ";
    return _db.Query<Monster, MonsterModel, Monster>(sql, (monster, monsterModel) =>
    {
      monster.monsterSprite = monsterModel;
      return monster;
    }, new { id }).FirstOrDefault();
  }

  internal Monster Create(Monster newMonster)
  {
    string sql = @"
            INSERT INTO monsters
              (name, health, attack, gold, picture, description, isBoss, monsterModel)
            VALUES
              (@Name, @Health, @Attack, @Gold, @picture, @Description, @IsBoss, @MonsterModel);
            SELECT LAST_INSERT_ID();";
    newMonster.id = _db.ExecuteScalar<int>(sql, newMonster);
    return newMonster;
  }

  internal Monster Edit(Monster editData)
  {
    string sql = @"
            UPDATE monsters
            SET 
              name = @Name,
              health = @Health,
              attack = @Attack,
              gold = @Gold,
              picture = @Picture,
              description = @Description,
              isBoss = @IsBoss,
              monsterModel = @MonsterModel
            WHERE id = @Id;";
    _db.Execute(sql, editData);
    return editData;
  }

  internal void Delete(Monster original)
  {
    string sql = @"DELETE FROM monsters WHERE id = @Id";
    _db.Execute(sql, original);
  }
}
