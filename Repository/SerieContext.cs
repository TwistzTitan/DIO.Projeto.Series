


using DIO.Projeto.Series.Domain.Series;
using Microsoft.EntityFrameworkCore;

namespace DIO.Projeto.Series.Repository
{
    public class SerieContext : DbContext
    {
        public DbSet<Serie> Series { get; set; }

        public SerieContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)

                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB ; Database=EntretenimentoDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        
    }
}