using DatingApp.Server.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Server.Controllers
{
    [ServiceFilter(typeof(LogUsersActivity))]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        
    }
}