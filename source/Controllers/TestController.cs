using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Misa.SmeNetCore.Handlers;

namespace Misa.SmeNetCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]   
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("welcome to service");
        }
    }
}