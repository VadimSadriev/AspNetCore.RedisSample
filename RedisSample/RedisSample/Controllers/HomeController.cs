using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedisSample.Cache;
using RedisSample.Data;
using System.Threading.Tasks;

namespace RedisSample.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<HomeController> _logger;


        public HomeController(DataContext context,
            ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Cache(600)]
        public async Task<IActionResult> Get()
        {
            return Ok(_context.Posts);
        }
    }
}
