using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Noto
{
    class NotoDBContext : DbContext
    {
        //Tables in database
        public DbSet<Note> Notes { get; set; }
        
        //Method for connecting to a database with specified connection string name on configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // "DefaultConnection" - connection string name
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString);
        }
    }
}
