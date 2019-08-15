using StarWarPlanets.Domain.Contratos;
using StarWarPlanets.Domain.Entidades;
using StarWarPlanets.Repository.Context;

namespace StarWarPlanets.Repository.Repositories
{
    public class PlanetaRepository : BaseRepository<Planeta>, IPlanetaRepository
    {
        //Passa a instância do context para a classe pai      
        public PlanetaRepository(StarWarPlanetContext starWarPlanetContext) : base(starWarPlanetContext)
        {
        }
    }
}
