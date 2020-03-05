using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.LottoCap.Domain.Entities;

namespace Teste.LottoCap.Service.Validators
{
    /// <summary>
    /// Classe de validação dos valores inputados
    /// </summary>
    public class ValoresValidator : AbstractValidator<Valores>
    {
        /// <summary>
        /// Inicialização da clase de validação
        /// </summary>
        public ValoresValidator()
        {
            RuleFor(c => c).NotNull()
            .OnAnyFailure(x =>
            {
                throw new ArgumentNullException("O objeto deve ser iniciado.");
            });

            RuleFor(c => c.De)
            .NotEmpty().WithMessage("Necessário informar o valor De para ser modificado.");

            RuleFor(c => c.Para)
            .NotEmpty().WithMessage("Necessário informar o valor Para a ser modificado.");
        }
    }
}
