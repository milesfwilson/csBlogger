using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using csBlogger.Models;
using csBlogger.Services;
using Microsoft.AspNetCore.Mvc;

namespace csBlogger.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class BlogsController : ControllerBase
  {
    private readonly BlogsService _bs;
    public BlogsController(BlogsService bs)
    {
      _bs = bs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Blog>> Get()
    {
      try
      {
        return Ok(_bs.Get());
      }
      catch (System.Exception error)
      {

        return BadRequest(error.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Blog> GetOne(int id)
    {
      try
      {
        return Ok(_bs.GetOne(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpGet("{id}/comment")]
    public ActionResult<Comment> GetCommentsByBlog(int id)
    {
      try
      {
        return Ok(_bs.GetCommentsByBlog(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }


    [HttpPost]
    public async Task<ActionResult<Blog>> Create([FromBody] Blog newBlog)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newBlog.CreatorId = userInfo.Id;
        Blog created = _bs.Create(newBlog);
        created.Creator = userInfo;
        return Ok(created);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPost("{id}/comment")]
    public async Task<ActionResult<Comment>> CreateCommentFromBlog([FromBody] Comment newComment, int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newComment.CreatorId = userInfo.Id;
        newComment.BlogId = id;
        Comment created = _bs.CreateCommentFromBlog(newComment);
        created.Creator = userInfo;
        return Ok(created);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<IEnumerable<Blog>> Edit([FromBody] Blog editedBlog, int id)
    {
      try
      {
        return Ok(_bs.Edit(editedBlog, id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

  }
}