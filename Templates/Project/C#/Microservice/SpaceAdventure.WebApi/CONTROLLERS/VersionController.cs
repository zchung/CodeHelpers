using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace $safeprojectname$.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VersionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            return Ok(version);
        }
    }
}