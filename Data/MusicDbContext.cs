using Microsoft.EntityFrameworkCore;
using MusicShop.Models;

namespace MusicShop.Data
{
    public class MusicDbContext:DbContext
    {

        public DbSet<Products> Products { get; set; }
        public DbSet<Categorey> Categoreys { get; set; }

        public MusicDbContext(DbContextOptions<MusicDbContext> options) :base(options)
        {
            
        }

    }
}
