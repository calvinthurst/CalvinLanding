namespace CalvinLanding.Repositories;

public class AccountItemRepository
{
  private readonly IDbConnection _db;

  public AccountItemRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<AccountItems> Get()
  {
    string sql = "SELECT * FROM accountitems";
    return _db.Query<AccountItems>(sql).ToList();
  }

  public AccountItems Get(int id)
  {
    string sql = @"SELECT 
    ai.*,
    i.*,
    a.*
    FROM accountItems ai
    JOIN items i ON ai.itemId = i.id
    JOIN accounts a ON ai.accountId = a.id
    WHERE ai.id = @id;";
    return _db.Query<AccountItems, Item, Account, AccountItems>(sql, (accountItem, item, account) =>
    {
      accountItem.item = item;
      accountItem.account = account;
      return accountItem;
    }, new { id }).FirstOrDefault();
  }

  public List<AccountItems> GetByAccountId(string accountId)
  {
    string sql = @"SELECT 
    ai.*,
    i.*,
    a.*
    FROM accountItems ai
    JOIN items i ON ai.itemId = i.id
    JOIN accounts a ON ai.accountId = a.id
    WHERE ai.accountId = @accountId;";
    return _db.Query<AccountItems, Item, Account, AccountItems>(sql, (accountItem, item, account) =>
    {
      accountItem.item = item;
      accountItem.account = account;
      return accountItem;
    }, new { accountId }).ToList();
  }

  public int Create(AccountItems newItem)
  {
    string sql = @"
        INSERT INTO accountitems
        ( itemId, quantity)
        VALUES
        ( @ItemId, @Quantity);
        SELECT LAST_INSERT_ID();";
    return _db.ExecuteScalar<int>(sql, newItem);
  }

  public bool Edit(AccountItems editData)
  {
    string sql = @"
        UPDATE accountitems
        SET
            accountId = @AccountId,
            itemId = @ItemId,
            quantity = @Quantity
        WHERE id = @Id;";
    int affectedRows = _db.Execute(sql, editData);
    return affectedRows == 1;
  }

  public bool Delete(int id)
  {
    string sql = "DELETE FROM accountitems WHERE id = @id LIMIT 1";
    int affectedRows = _db.Execute(sql, new { id });
    return affectedRows == 1;
  }
}
