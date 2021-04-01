

using System.Data.Entity;
using DIO.Projeto.Series.Domain.Series;


namespace DIO.Projeto.Series.Repository
{
    public class SerieContext : DbContext
    {

        public SerieContext() : base("EntretenimentoDB")
        {

            Database.SetInitializer<SerieContext>(new DropCreateDatabaseIfModelChanges<SerieContext>());

        }


        public DbSet<Serie> Series { get; set; }
        

        
    }
}