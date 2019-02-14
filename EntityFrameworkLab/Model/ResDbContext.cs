using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLab.Model
{
    public class ResDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Monograph> Monographs { get; set; }
        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Researcher> Researchers { get; set; }

        public ResDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "Researchers.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);
        }
    }
}