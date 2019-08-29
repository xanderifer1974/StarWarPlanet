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
            /// Retorna planeta por nome
            /// </summary>
            /// <returns></returns>  
            [HttpGet("[action]")]
            public IActionResult GetByNome([FromQuery] string nome)
            {

                try
                {
                    var planeta = _planetaRepository.ObterPlanetaPorNome(nome);
                   
                    if (planeta == null)
                    {
                        return BadRequest("Nome do Planeta não encontrado.");
                    }
                    else
                    {
                        return Ok(planeta);
                    }


                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }
            }

            /// <summary>
            /// Retorna todos os planetas por id
            /// /api/planeta/id
            /// </summary>
            /// <returns></returns>  
            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {

                try
                {
                    return Ok(_planetaRepository.ObterPorId(id));

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

            // PUT: api/Planeta/5
            [HttpPut("{id}")]
            public IActionResult AlterarPlaneta(int id, [FromBody] Planeta planeta)
            {
                try
                {
                    if (id != planeta.Id)
                    {
                        return BadRequest("Id não corresponde ao planeta a ser alterado.");
                    }

                    _planetaRepository.Atualizar(planeta);


                    return Ok(planeta);
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.ToString());
                }
            }

        }
        
    }
}
