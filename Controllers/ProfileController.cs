using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using csBlogger.Models;
using csBlogger.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csBlogger.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ProfileController : ControllerBase
  {

    private readonly ProfilesService _ps;
    public ProfileController(ProfilesService ps)
    {
      _ps = ps;
    }
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

  }
}