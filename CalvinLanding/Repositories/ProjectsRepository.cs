namespace CalvinLanding.Repositories;

public class ProjectsRepository
{
  private readonly IDbConnection _db;

  public ProjectsRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Project> Get()
  {
    string sql = "SELECT * FROM projects";
    return _db.Query<Project>(sql).ToList();
  }

  public Project Get(int id)
  {
    string sql = "SELECT * FROM projects WHERE id = @id";
    return _db.QueryFirstOrDefault<Project>(sql, new { id });
  }

  public Project Create(Project newItem)
  {
    string sql = @"
            INSERT INTO projects
            (title, description, picture, gitHubUrl, deployedUrl)
            VALUES
            (@Title, @Description, @Img, @gitHubUrl, @DeployedUrl);
            SELECT LAST_INSERT_ID();";
    int id = _db.ExecuteScalar<int>(sql, newItem);
    newItem.id = id;
    return newItem;
  }

  public bool Edit(Project editData)
  {
    string sql = @"
            UPDATE projects
            SET
                title = @Title,
                description = @Description,
                picture = @picture,
                gitHubUrl = @gitHubUrl,
                deployedUrl = @DeployedUrl
            WHERE id = @Id;";
    int affectedRows = _db.Execute(sql, editData);
    return affectedRows == 1;
  }

  public bool Delete(int id)
  {
    string sql = "DELETE FROM projects WHERE id = @id LIMIT 1";
    int affectedRows = _db.Execute(sql, new { id });
    return affectedRows == 1;
  }
}
