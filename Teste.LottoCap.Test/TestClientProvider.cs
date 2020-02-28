using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace Teste.LottoCap.Test
{
    /// <summary>
    /// Clase para provider com a api
    /// </summary>
    internal class TestClientProvider:IDisposable
    {
        /// <summary>
        /// Propriedade que contem o server de teste da api
        /// </summary>
        private TestServer server;

        /// <summary>
        /// Propriedade que contem o cliente de teste da api
        /// </summary>
        public HttpClient Client { get; private set; }

        /// <summary>
        /// Na inicializacaoda classe ja cria o web server
        /// </summary>
        public TestClientProvider()
        {
            server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());

            Client = server.CreateClient();
        }


        /// <summary>
        /// Quando a classe deixa de ser utilizada descarrega o server e o cliente
        /// </summary>
        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}
