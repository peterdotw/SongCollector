using Microsoft.EntityFrameworkCore;
using SongCollector.Models;

namespace SongCollector.Data
{
    public class SongCollectorContext : DbContext
    {
        public SongCollectorContext(DbContextOptions<SongCollectorContext> opt) : base(opt)
        {

        }

        public DbSet<Song> Songs { get; set; }
    }
}