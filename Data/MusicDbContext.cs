using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicShop.Models;

namespace MusicShop.Data
{
    public class MusicDbContext : IdentityDbContext<User>
    {

        public DbSet<Products> Products { get; set; }
        public DbSet<Categorey> Categoreys { get; set; }
        public DbSet<User> Users { get; set; }

        public MusicDbContext(DbContextOptions<MusicDbContext> options) :base(options)
        {
            
        }

    }
}
