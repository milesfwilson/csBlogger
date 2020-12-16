using System;
using System.Collections.Generic;
using System.Data;
using csBlogger.Models;
using Dapper;

namespace csBlogger.Repositories
{


  public class CommentsRepository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = "SELECT comment.*, profile.* FROM comments comment INNER JOIN profiles2 profile ON comment.creatorId = profile.id ";
    public CommentsRepository(IDbConnection db)
    {
      _db = db;
    }

    public int Create(Comment newComment)
    {
      string sql = @"
                INSERT INTO comments
                (content, creatorId, blogId)
                VALUES
                (@Content, @CreatorId, @BlogId);
                SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newComment);
    }

    public bool Delete(int id)
    {
      string sql = "DELETE FROM comments WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    public IEnumerable<Comment> Get()
    {
      string sql = populateCreator;
      return _db.Query<Comment, Profile, Comment>(sql, (comment, profile) => { comment.Creator = profile; return comment; }, splitOn: "id");
    }
  }
}