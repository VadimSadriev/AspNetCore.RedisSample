using Microsoft.AspNetCore.Mvc;
using RedisSample.Data;
using RedisSample.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace RedisSample.Controllers
{
    [Route("api/[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly DataContext _context;

        public SeedController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Seed()
        {
            Enumerable.Range(0, 10).ToList()
                .ForEach(async x =>
                {
                    await _context.Posts.AddAsync(new Post { Name = $"Post number {x}" });
                    await _context.Tags.AddAsync(new Tag { Name = $"Tag number {x}" });
                });
            await _context.SaveChangesAsync();

            return Ok("Seeding complete");
        }
    }
}
