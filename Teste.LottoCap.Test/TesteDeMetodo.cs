using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Teste.LottoCap.Domain.Entities;
using Xunit;

namespace Teste.LottoCap.Test
{
    /// <summary>
    /// Classe de teste de metodos
    /// </summary>
    public class TesteDeMetodo
    {
        /// <summary>
        /// Método para teste de Urso para Pato
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Urso_Pato()
        {
            //Cria o web server
            using (var client = new TestClientProvider().Client)
            {
                //Cria a chamada para a api passando os dados
                HttpResponseMessage response = await client.PostAsync("/api/ModValor"
                , new StringContent(
                JsonConvert.SerializeObject(new Valores()
                {
                    De = "Urso",
                    Para = "Pato"
                }),
                Encoding.UTF8, "application/json"));

                //Pega o retorno da chamada
                Valores DadosRetornados = response.Content.ReadAsAsync<Valores>().Result;
                Assert.Equal(3,DadosRetornados.Quantidade);


            }

        }

        /// <summary>
        /// Método para teste de Pato para Rato
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Pato_Rato()
        {
            //Cria o web server
            using (var client = new TestClientProvider().Client)
            {
                //Cria a chamada para a api passando os dados
                HttpResponseMessage response = await client.PostAsync("/api/ModValor"
                , new StringContent(
                JsonConvert.SerializeObject(new Valores()
                {
                    De = "Urso",
                    Para = "Pato"
                }),
                Encoding.UTF8, "application/json"));

                //Pega o retorno da chamada
                Valores DadosRetornados = response.Content.ReadAsAsync<Valores>().Result;
                Assert.Equal(3, DadosRetornados.Quantidade);


            }

        }
        /// <summary>
        /// Método para teste de Cavalo para Rato
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Cavalo_Pato()
        {
            //Cria o web server
            using (var client = new TestClientProvider().Client)
            {
                //Cria a chamada para a api passando os dados
                HttpResponseMessage response = await client.PostAsync("/api/ModValor"
                , new StringContent(
                JsonConvert.SerializeObject(new Valores()
                {
                    De = "Cavalo",
                    Para = "Pato"
                }),
                Encoding.UTF8, "application/json"));

                //Pega o retorno da chamada
                Valores DadosRetornados = response.Content.ReadAsAsync<Valores>().Result;
                Assert.Equal(4, DadosRetornados.Quantidade);


            }

        }
    }
}
