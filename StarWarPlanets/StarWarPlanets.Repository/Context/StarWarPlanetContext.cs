using Microsoft.EntityFrameworkCore;
using StarWarPlanets.Domain.Entidades;
using StarWarPlanets.Repository.Config;

namespace StarWarPlanets.Repository.Context
{
    public class StarWarPlanetContext: DbContext
    {
        public  DbSet<Planeta> Planetas { get; set; }     

        public StarWarPlanetContext(DbContextOptions options) : base(options)
        {           

        }

        public StarWarPlanetContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlanetaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
