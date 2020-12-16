using System;
using System.Data;
using csBlogger.Models;
using Dapper;

namespace csBlogger.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    public Profile GetByEmail(string email)
    {
      string sql = "SELECT * FROM profiles2 WHERE email = @Email";
      return _db.QueryFirstOrDefault<Profile>(sql, new { email });
    }

    public Profile Create(Profile userInfo)
    {
      string sql = @"
        INSERT INTO profiles2
        (name, picture, email, id)
        VALUES
        (@Name, @Picture, @Email, @Id)";
      _db.Execute(sql, userInfo);
      return userInfo;
    }
  }
}