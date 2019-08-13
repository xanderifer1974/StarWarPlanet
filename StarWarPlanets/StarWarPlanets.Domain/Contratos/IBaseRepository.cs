﻿using System;
using System.Collections.Generic;

namespace StarWarPlanets.Domain.Contratos
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity entity);

        TEntity ObterPorNome(string nome);

        TEntity ObterPorId(int id);

        IEnumerable<TEntity> ObterTodos();

        void Atualizar(TEntity entity);

        void Remover(TEntity entity);
    }
}
