using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using csBlogger.Models;
using csBlogger.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csBlogger.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CommentController : ControllerBase
  {
    private readonly CommentsService _cs;


    public CommentController(CommentsService cs)
    {
      _cs = cs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Comment>> Create([FromBody] Comment newComment)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newComment.CreatorId = userInfo.Id;
        Comment created = _cs.Create(newComment);
        created.Creator = userInfo;
        return Ok(created);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Comment>> Get()
    {
      try
      {
        return Ok(_cs.Get());
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
        return Ok(_cs.Delete(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

  }
}