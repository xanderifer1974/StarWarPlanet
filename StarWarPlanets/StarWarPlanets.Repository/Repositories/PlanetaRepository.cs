using Microsoft.EntityFrameworkCore;
using StarWarPlanets.Domain.Contratos;
using StarWarPlanets.Domain.Entidades;
using StarWarPlanets.Repository.Context;
using System.Linq;

namespace StarWarPlanets.Repository.Repositories
{
    public class PlanetaRepository : BaseRepository<Planeta>, IPlanetaRepository
    {
        //Passa a instância do context para a classe pai      
        public PlanetaRepository(StarWarPlanetContext starWarPlanetContext) : base(starWarPlanetContext)
        {
        }
      

        public Planeta ObterPlanetaPorNome(string nome)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StarWarPlanetContext>();

            var dbcontext = new StarWarPlanetContext(optionsBuilder.Options);
           
            return dbcontext.Planetas.FirstOrDefault(p => p.Nome == nome);
        }
    }
}
