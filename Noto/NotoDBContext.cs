using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Internal;

namespace Noto
{
    class NotoDBContext : DbContext
    {
        //Tables in database
        public DbSet<Note> Notes { get; set; }

        //Method for connecting to a database with specified connection string name on configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionStringName = "LocalConnection";
            string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            // "DefaultConnection" - connection string name
            if (connectionStringName == "LocalConnection")
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            else if (connectionStringName == "DefaultConnection")
            {
                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(5, 5, 62)));
            }
        }
    }
}
