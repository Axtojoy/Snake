using Microsoft.EntityFrameworkCore;
using Snake.Domain.Models.Game;

namespace Snake.DAL
{
    public class PostgreeContext: DbContext
    {
        public PostgreeContext(DbContextOptions<PostgreeContext> options)
           : base(options)
        {
        }
        public DbSet<Game> Game => Set<Game>();
    }
}