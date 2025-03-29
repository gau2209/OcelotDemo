using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPICart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> First()
        {
            await Task.Delay(6000);
            return Ok("Cart service - First");
        }

        [HttpGet("Second")]
        public string Second()
        {
            throw new Exception("hehe");
        }

    }
}
