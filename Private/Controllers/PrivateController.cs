using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Private.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateController : ControllerBase
    {
        // GET: api/<PrivateController>
        [HttpGet("First")]
        public string First()
        {
            return "Private service - First";
        }
        [Authorize]
        [HttpGet("Second")]
        public string Second()
        {
            return "Private service - Second()";
        }


    }
}
