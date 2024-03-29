﻿using StarWarPlanets.Domain.Entidades;

namespace StarWarPlanets.Domain.Contratos
{
   public interface IPlanetaRepository: IBaseRepository<Planeta>
    {
        Planeta ObterPlanetaPorNome(string nome);
    }
}
