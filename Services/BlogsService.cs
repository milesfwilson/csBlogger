using System;
using System.Collections.Generic;
using csBlogger.Models;
using csBlogger.Repositories;

namespace csBlogger.Services
{
  public class BlogsService
  {
    private readonly BlogsRepository _repo;

    public BlogsService(BlogsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Blog> Get()
    {
      return _repo.Get();
    }
    public Blog GetOne(int id)
    {
      Blog foundBlog = _repo.GetOne(id);
      if (foundBlog == null)
      {
        throw new Exception("There is no Blog");
      }
      return foundBlog;
    }
    public IEnumerable<Comment> GetCommentsByBlog(int id)
    {
      IEnumerable<Comment> comments = _repo.GetCommentsByBlog(id);
      if (comments == null)
      {
        throw new Exception("There is no Blog");
      }
      return comments;
    }

    public Blog Create(Blog newBlog)
    {

      newBlog.Id = _repo.Create(newBlog);
      return newBlog;
    }
    public Comment CreateCommentFromBlog(Comment newComment)
    {
      newComment.Id = _repo.CreateCommentFromBlog(newComment);
      return newComment;
    }

    public string Delete(int id)
    {
      if (_repo.Delete(id))
      {
        return "Deleted!";
      }
      throw new Exception("Failure");

    }

    public Blog Edit(Blog editedBlog, int id)
    {
      Blog foundBlog = _repo.GetOne(id);
      editedBlog.Id = foundBlog.Id;
      editedBlog.Title = editedBlog.Title == null ? foundBlog.Title : editedBlog.Title;
      editedBlog.CreatorId = editedBlog.CreatorId == null ? foundBlog.CreatorId : editedBlog.CreatorId;

      editedBlog.Content = editedBlog.Content == null ? foundBlog.Content : editedBlog.Content;

      editedBlog.IsPublished = editedBlog.IsPublished == false ? foundBlog.IsPublished : editedBlog.IsPublished;

      return _repo.Edit(editedBlog, id);
    }

  }
}