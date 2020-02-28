using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Teste.LottoCap.Saida;

namespace Teste.LottoCap.Util
{
    /// <summary>
    /// Classe interna de apoio com utilidades
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// Método para reover acencução e caracteres especiais usando linq
        /// </summary>
        /// <param name="text">Texto a ser transformado</param>
        /// <returns>Retorna a string sem os caracteres especiais</returns>
        public static string RemoverAcentuacao(this string text)
        {
            string Retorno = string.Empty;
            if (!string.IsNullOrWhiteSpace(text))
            {
                Retorno = new string(text
                    .Normalize(NormalizationForm.FormD)
                    .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                    .ToArray());
            }

            return Retorno;
        }

        public static int ContarIncidencia(this string Valor, string Pattern)
        {
            int Retorno = 0;
            if (!string.IsNullOrWhiteSpace(Valor))
            {
                Retorno = Regex.Matches(Valor, Pattern).Where(c => !string.IsNullOrWhiteSpace(c.Value)).ToList().Count();
                if (Retorno > 0)
                {
                    Retorno = Retorno - 1;
                }
            }

            return Retorno;
        }

        /// <summary>
        /// Método para criar retorno comum da controller
        /// </summary>
        /// <param name="Mensagem">Mensagem a ser retornada em caso de sucesso</param>
        /// <param name="Quantidade">Quantidade de incidencias de palavras</param>
        /// <returns>Retorna a classe preenchida pronta para retorno</returns>
        public static RetornoClasse CriarRetorno(this string Mensagem, int Quantidade)
        {
            RetornoClasse retorno = new RetornoClasse();
            retorno.Mensagem = Mensagem;
            retorno.Quantidade = Quantidade;
            return retorno;
        }

        /// <summary>
        /// Método para criar retorno comum da controller
        /// </summary>
        /// <param name="Mensagem">Mensagem a ser retornada em caso de erro</param>
        /// <param name="Trace">Caso ocorra um erro sera enviado o trace</param>
        /// <returns>Retorna a classe preenchida pronta para retorno</returns>
        public static RetornoClasse CriarRetorno(this string Mensagem, string Trace)
        {
            RetornoClasse retorno = new RetornoClasse();
            retorno.Erro = new Erros()
            {
                Mensagem = Mensagem,
                StackTrace = Trace
            };


            return retorno;
        }
    }
}
