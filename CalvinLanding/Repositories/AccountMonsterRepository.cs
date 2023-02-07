namespace CalvinLanding.Repositories;

public class AccountMonsterRepository
{
  private readonly IDbConnection _db;

  public AccountMonsterRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<AccountMonsters> Get()
  {
    string sql = "SELECT * FROM accountMonsters";
    return _db.Query<AccountMonsters>(sql).ToList();
  }

  public AccountMonsters Get(int id)
  {
    string sql = @"SELECT 
        am.*,
        m.*,
        a.*
        FROM accountMonsters am
        JOIN monsters m ON am.monsterId = m.id
        JOIN accounts a ON am.accountId = a.id
        WHERE am.id = @id;";
    return _db.Query<AccountMonsters, Monster, Account, AccountMonsters>(sql, (accountMonster, monster, account) =>
    {
      accountMonster.monster = monster;
      accountMonster.account = account;
      return accountMonster;
    }, new { id }).FirstOrDefault();
  }

  public List<AccountMonsters> GetByAccountId(string accountId)
  {
    string sql = @"SELECT 
        am.*,
        m.*,
        a.*
        FROM accountMonsters am
        JOIN monsters m ON am.monsterId = m.id
        JOIN accounts a ON am.accountId = a.id
        WHERE am.accountId = @accountId;";
    return _db.Query<AccountMonsters, Monster, Account, AccountMonsters>(sql, (accountMonster, monster, account) =>
    {
      accountMonster.monster = monster;
      accountMonster.account = account;
      return accountMonster;
    }, new { accountId }).ToList();
  }

  public AccountMonsters Create(AccountMonsters newItem)
  {
    string sql = @"
        INSERT INTO accountMonsters
        ( monsterId, accountId)
        VALUES
        ( @MonsterId, @AccountId);
        SELECT LAST_INSERT_ID();";
    return _db.ExecuteScalar<AccountMonsters>(sql, newItem);
  }

  public AccountMonsters Edit(AccountMonsters updatedItem)
  {
    string sql = @"
        UPDATE accountMonsters
        SET
            monsterId = @MonsterId,
            accountId = @AccountId
        WHERE id = @Id;
        SELECT * FROM accountMonsters WHERE id = @Id;";
    return _db.QueryFirstOrDefault<AccountMonsters>(sql, updatedItem);
  }

  public bool Delete(int id)
  {
    string sql = "DELETE FROM accountMonsters WHERE id = @id LIMIT 1";
    int affectedRows = _db.Execute(sql, new { id });
    return affectedRows == 1;
  }
}
