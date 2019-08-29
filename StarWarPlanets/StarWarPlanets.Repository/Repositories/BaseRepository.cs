using System.Collections.Generic;
using System.Linq;
using StarWarPlanets.Domain.Contratos;
using StarWarPlanets.Repository.Context;

namespace StarWarPlanets.Repository.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adicionando referência a classe DbContext
        /// </summary>
        private readonly StarWarPlanetContext StarWarPlanetContext;

        public BaseRepository(StarWarPlanetContext starWarPlanetContext)
        {
            StarWarPlanetContext = starWarPlanetContext;
        }

        public void Adicionar(TEntity entity)
        {
            StarWarPlanetContext.Set<TEntity>().Add(entity);
            StarWarPlanetContext.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            if (entity != null)
            {
                StarWarPlanetContext.Set<TEntity>().Update(entity);
                StarWarPlanetContext.SaveChanges();
            }           
           
        }      

        public TEntity ObterPorId(int id)
        {
            return StarWarPlanetContext.Set<TEntity>().Find(id);
        }
               

        public IEnumerable<TEntity> ObterTodos()
        {
            return StarWarPlanetContext.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entity)
        {
            if (entity != null)
            {
                StarWarPlanetContext.Remove(entity);
                StarWarPlanetContext.SaveChanges();
            }
           
        }

        public void Dispose()
        {
            StarWarPlanetContext.Dispose();
        }
    }
}
