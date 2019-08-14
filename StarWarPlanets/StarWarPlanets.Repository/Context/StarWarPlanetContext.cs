using Microsoft.EntityFrameworkCore;
using StarWarPlanets.Domain.Entidades;

namespace StarWarPlanets.Repository.Context
{
    public class StarWarPlanetContext: DbContext
    {
        public DbSet<Planeta> Planetas { get; set; }

    }
}
