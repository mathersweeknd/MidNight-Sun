using Microsoft.EntityFrameworkCore;
using Clima.Models;

namespace Clima.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Weather> Climas { get; set; }
    }
}