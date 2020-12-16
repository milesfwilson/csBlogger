using System;
using System.Collections.Generic;
using System.Data;
using csBlogger.Models;
using Dapper;

namespace csBlogger.Repositories
{
  public class BlogsRepository
  {
    private readonly IDbConnection _db;

    private readonly string populateCreator = "SELECT blog.*, profile.* FROM blogs3 blog INNER JOIN profiles2 profile ON blog.creatorId = profile.Id ";

    public BlogsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Blog> Get()
    {
      string sql = populateCreator + "WHERE isPublished = 1";
      return _db.Query<Blog, Profile, Blog>(sql, (blog, profile) => { blog.Creator = profile; return blog; }, splitOn: "id");
    }

    public IEnumerable<Comment> GetCommentsByBlog(int id)
    {
      string sql = "SELECT comment.*, profile.* FROM comments comment INNER JOIN profiles2 profile ON comment.creatorId = profile.Id WHERE blogId = @Id";
      //   return _db.Query<Comment>(sql, new { id });
      return _db.Query<Comment, Profile, Comment>(sql, (comment, profile) => { comment.Creator = profile; return comment; }, new { id }, splitOn: "id");
    }


    public Blog GetOne(int id)
    {
      string sql = "SELECT * FROM blogs3 WHERE id = @Id";
      return _db.QueryFirstOrDefault<Blog>(sql, new { id });
    }

    public int Create(Blog newBlog)
    {
      string sql = @"INSERT INTO blogs3
                    (title, creatorId, content, isPublished)
                    VALUES
                    (@Title, @CreatorId, @Content, @IsPublished);
                    SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newBlog);
    }
    public int CreateCommentFromBlog(Comment newComment)
    {
      string sql = @"INSERT INTO comments 
            (content, creatorId, blogId)
            VALUES
            (@Content, @CreatorId, @BlogId);
            SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newComment);
    }

    public bool Delete(int id)
    {
      string sql = "DELETE FROM blogs3 WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    public Blog Edit(Blog editedBlog, int id)
    {
      string sql = "UPDATE blogs3 SET title = @Title, creatorId = @CreatorId, content = @Content, isPublished = @IsPublished WHERE id = @Id";
      _db.Execute(sql, editedBlog);
      return GetOne(id);
    }
  }
}