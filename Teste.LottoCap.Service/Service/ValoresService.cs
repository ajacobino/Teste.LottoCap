using FluentValidation;
using System;
using Teste.LottoCap.CrossCutting.ModificarValor;
using Teste.LottoCap.Domain.Entities;
using Teste.LottoCap.Domain.Interface;

namespace Teste.LottoCap.Service.Service
{
    /// <summary>
    /// Classe que sera a base do serviço
    /// </summary>
    /// <typeparam name="T">Classe que sera utilizada pelo serviço</typeparam>
    public class ValoresService<T> : IService<T> where T : BaseEntity
    {
        /// <summary>
        /// Método que faz o post dos dados
        /// </summary>
        /// <typeparam name="V">Classe que sera utilizada para controle dos dados</typeparam>
        /// <param name="obj">Objeto com os dados</param>
        /// <returns>Retorna o objeto ja preenchido</returns>
        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());
            new ModValor<T>().ModificarValor(obj);
            return obj;

        }

        /// <summary>
        /// Valida os dados de entrada
        /// </summary>
        /// <param name="obj">Objeto a ser validado</param>
        /// <param name="validator">Instancia da classe</param>
        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
