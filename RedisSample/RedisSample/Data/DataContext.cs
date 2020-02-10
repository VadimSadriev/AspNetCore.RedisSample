using Microsoft.EntityFrameworkCore;
using RedisSample.Data.Entities;

namespace RedisSample.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
