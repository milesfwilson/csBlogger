using System;
using System.Collections.Generic;
using csBlogger.Models;
using csBlogger.Repositories;

namespace csBlogger.Services
{
  public class CommentsService
  {

    private readonly CommentsRepository _repo;

    public CommentsService(CommentsRepository repo)
    {
      _repo = repo;
    }

    public Comment Create(Comment newComment)
    {
      newComment.Id = _repo.Create(newComment);
      return newComment;
    }

    public IEnumerable<Comment> Get()
    {
      return _repo.Get();
    }

    public string Delete(int id)
    {
      if (_repo.Delete(id))
      {
        return "Deleted!";
      }
      throw new Exception("Failure");
    }
  }
}