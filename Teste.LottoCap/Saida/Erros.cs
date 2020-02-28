namespace Teste.LottoCap.Saida
{

    /// <summary>
    /// Classe que é responsavel caso ocorra algum tipo de erro
    /// </summary>
    public class Erros
    {
        /// <summary>
        /// Propriedade com a mensagem de erro
        /// </summary>
        public string Mensagem { get; set; }

        /// <summary>
        /// Propriedade com o trace de erro
        /// </summary>
        public string StackTrace { get; set; }
    }
}
