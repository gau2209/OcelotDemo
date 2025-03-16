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
        public string First()
        {
            return "Cart service - First";
        }

        [HttpGet("Second")]
        public string Second()
        {
            return "Cart service - Second";
        }

    }
}
