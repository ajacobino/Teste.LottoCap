using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Teste.LottoCap.Entrada;
using Teste.LottoCap.Saida;
using Xunit;

namespace Teste.LottoCap.Test
{
    /// <summary>
    /// Classe de teste de metodos
    /// </summary>
    public class TesteDeMetodo
    {
        /// <summary>
        /// Método que testa que retorno algum tipo de erro na primeira propriedade de retorno da api
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task InputString_Result_NotNull()
        {
            //Cria o web server
            using (var client = new TestClientProvider().Client)
            {
                //Cria a chamada para a api passando os dados
                HttpResponseMessage response = await client.PostAsync("/api/InputString"
                , new StringContent(
                JsonConvert.SerializeObject(new EntradaString()
                {
                    Entrada1 = "Alexandre testando",
                    Entrada2 = "Teste de aplicação"
                }),
                Encoding.UTF8, "application/json"));

                //Pega o retorno da chamada
                List<RetornoClasse> DadosRetornados = response.Content.ReadAsAsync<List<RetornoClasse>>().Result;
                Assert.Null(DadosRetornados[0].Erro);

                //poderia ser verificado pelo status code do retorno
                //response.EnsureSuccessStatusCode();
                //Assert.Equal(HttpStatusCode.OK, response.StatusCode);




            }

        }
    }
}
