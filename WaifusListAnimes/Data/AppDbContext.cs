using Microsoft.EntityFrameworkCore;
using WaifusListAnimes.Models;

namespace WaifusListAnimes.Data
{
    public class AppDbContext : DbContext
    {
        //ctor - comando
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Anime> Anime { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<AnimeGenero> AnimeGenero { get; set; }
    }
}