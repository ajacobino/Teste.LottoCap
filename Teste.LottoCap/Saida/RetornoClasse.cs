namespace Teste.LottoCap.Saida
{
    /// <summary>
    /// Classe que retorna os dados e erros caso ocorram
    /// </summary>
    public class RetornoClasse
    {
        /// <summary>
        /// Propriedade com a mensagem
        /// </summary>
        public string Mensagem { get; set; }

        /// <summary>
        /// Propriedade com a quantidade de incidencias das letras
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Propriedade caso ocorra algum erro
        /// </summary>
        public Erros Erro { get; set; }
    }
}
