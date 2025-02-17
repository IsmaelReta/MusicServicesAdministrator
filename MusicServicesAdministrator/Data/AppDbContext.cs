using Microsoft.EntityFrameworkCore;
using MusicServicesAdministrator.Models.Entities;

namespace MusicServicesAdministrator.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Platform> Platforms { get; set; }
    }
}
