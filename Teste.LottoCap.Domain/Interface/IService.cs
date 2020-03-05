using FluentValidation;
using Teste.LottoCap.Domain.Entities;

namespace Teste.LottoCap.Domain.Interface
{
    /// <summary>
    /// Interface para manter os métodos 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IService<T> where T : BaseEntity
    {
        /// <summary>
        /// Método que recebera os valores aserem processados
        /// </summary>
        /// <typeparam name="V">Objeto de retorno</typeparam>
        /// <param name="obj">Objeto com os inputs</param>
        /// <returns>Retorna o objeto processado</returns>
        T Post<V>(T obj) where V : AbstractValidator<T>;

    }
}
