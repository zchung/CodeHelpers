using Microsoft.AspNetCore.Mvc;

namespace $safeprojectname$.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}