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

        public DbSet<MusicServicesManager.Models.Platform> Platform { get; set; } = default!;
    }
}
