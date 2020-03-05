using System;
using Microsoft.AspNetCore.Mvc;
using Teste.LottoCap.Domain.Entities;
using Teste.LottoCap.Service.Service;
using Teste.LottoCap.Service.Validators;

namespace Teste.LottoCap.Controllers
{
    /// <summary>
    /// Controller principal de recebimento de strings
    /// </summary>
    [Produces("application/json")]
    [Route("api/ModValor")]
    [ApiController]
    public class ModValorController : ControllerBase
    {

        private ValoresService<Valores> service = new ValoresService<Valores>();

        /// <summary>
        /// Controller para entrada de dados 
        /// </summary>
        /// <param name="entrada">Classe que repesenta as strings de entrada de dados</param>
        /// <returns>Retorna um array em json com os resultados de incidencias ou erro caso ocorram</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Valores entrada)
        {
            try {
                service.Post<ValoresValidator>(entrada);
                return new ObjectResult(entrada);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
