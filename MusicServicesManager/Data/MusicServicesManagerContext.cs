using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicServicesManager.Models;

namespace MusicServicesManager.Data
{
    public class MusicServicesManagerContext : DbContext
    {
        public MusicServicesManagerContext (DbContextOptions<MusicServicesManagerContext> options)
            : base(options)
        {
        }

        public DbSet<MusicServicesManager.Models.Platform> Platforms { get; set; } = default!;
        public DbSet<MusicServicesManager.Models.Playlist> Playlists { get; set; } = default!;
        public DbSet<MusicServicesManager.Models.Author> Authors { get; set; } = default!;
        public DbSet<MusicServicesManager.Models.Song> Songs { get; set; } = default!;
    }
}
