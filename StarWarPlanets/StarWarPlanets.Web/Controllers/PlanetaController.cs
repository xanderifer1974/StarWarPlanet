namespace StarWarPlanets.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StarWarPlanets.Domain.Contratos;
    using StarWarPlanets.Domain.Entidades;
    using System;

    namespace QuickBuy.Web.Controllers
    {
        [Route("api/[Controller]")]
        public class PlanetaController : Controller
        {
            private readonly IPlanetaRepository _planetaRepository;
            public PlanetaController(IPlanetaRepository planetaRepository)
            {
                _planetaRepository = planetaRepository;
            }

            /// <summary>
            /// Retorna todos os planetas
            /// </summary>
            /// <returns></returns>  
            [HttpGet]
            public IActionResult Get()
            {

                try
                {
                    return Ok(_planetaRepository.ObterTodos());

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }
            }
            /// <summary>
            /// Insere um novo planeta no banco de dados
            /// </summary>
            /// <param name="produto"></param>
            /// <returns></returns>
            [HttpPost]
            public IActionResult Post([FromBody]Planeta planeta)
            {

                try
                {

                    _planetaRepository.Adicionar(planeta);
                    return Created("api/planeta", planeta);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }

            }
        }
    }
}
