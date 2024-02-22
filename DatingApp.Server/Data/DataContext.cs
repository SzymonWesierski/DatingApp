using DatingApp.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}