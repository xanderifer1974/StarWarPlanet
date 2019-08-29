using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
      

        /// <summary>
        /// Obtem planeta por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Planeta ObterPlanetaPorNome(string nome)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StarWarPlanetContext>();
            optionsBuilder.UseMySql("server=localhost;uid=root;pwd=duda0107;database=StarWarPlanetsDB;", m => m.MigrationsAssembly("StarWarPlanets.Repository"));
            var starWarPlanetContext = new StarWarPlanetContext(optionsBuilder.Options);
            return starWarPlanetContext.Planetas.FirstOrDefault(p => p.Nome == nome);
        }
    }
}
