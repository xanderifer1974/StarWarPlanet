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
            StarWarPlanetContext.Set<TEntity>().Update(entity);
            StarWarPlanetContext.SaveChanges();
        }      

        public TEntity ObterPorId(int id)
        {
            return StarWarPlanetContext.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Confirmar se o método está correto
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public TEntity ObterPorNome(string nome)
        {
            return StarWarPlanetContext.Set<TEntity>().Find(nome);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return StarWarPlanetContext.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entity)
        {
            StarWarPlanetContext.Remove(entity);
            StarWarPlanetContext.SaveChanges();
        }

        public void Dispose()
        {
            StarWarPlanetContext.Dispose();
        }
    }
}
