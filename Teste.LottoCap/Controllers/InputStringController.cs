using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste.LottoCap.Entrada;
using Teste.LottoCap.Saida;

namespace Teste.LottoCap.Controllers
{
    /// <summary>
    /// Controller principal de recebimento de strings
    /// </summary>
    [Produces("application/json")]
    [Route("api/InputString")]
    [ApiController]
    public class InputStringController : ControllerBase
    {
        /// <summary>
        /// Controller para entrada de dados 
        /// </summary>
        /// <param name="entrada">Classe que repesenta as strings de entrada de dados</param>
        /// <returns>Retorna um array em json com os resultados de incidencias ou erro caso ocorram</returns>
        [HttpPost]
        public Task<List<RetornoClasse>> Post([FromBody] EntradaString entrada)
        {
            List<RetornoClasse> Retorno = new List<RetornoClasse>();
            try
            {
                //Pattner que valida a incidencia de letras nas strings
                string pattern = @"[C*c*A*a*V*v*L*l*P*p*T*t*]";

                //Verifica se foi enviado as duas strings
                if (string.IsNullOrWhiteSpace(entrada.Entrada1) && string.IsNullOrWhiteSpace(entrada.Entrada2))
                {

                    Retorno.Add(Util.Utils.CriarRetorno("Valores de entrada devem ser informados.",""));
                    return Task.FromResult(Retorno);
                }

                //Monta as incidencias das letras
                Retorno.Add(Util.Utils.CriarRetorno("Quantidade de Incidencias na Entrada1", Util.Utils.ContarIncidencia(Util.Utils.RemoverAcentuacao(entrada.Entrada1), pattern)));
                Retorno.Add(Util.Utils.CriarRetorno("Quantidade de Incidencias na Entrada2", Util.Utils.ContarIncidencia(Util.Utils.RemoverAcentuacao(entrada.Entrada2), pattern)));


            }
            catch (Exception ex)
            {
                Retorno.Add(Util.Utils.CriarRetorno(ex.Message, ex.StackTrace));
            }

            return Task.FromResult(Retorno);
        }

    }
}
