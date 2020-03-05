using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.LottoCap.Domain.Entities
{
    /// <summary>
    /// Classe Base com as propriedades obrigatorias
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Propriedade de entrada com o valor informado
        /// </summary>
        public virtual string De { get; set; }

        /// <summary>
        /// Propriedade de entrada com o valor informado
        /// </summary>
        public virtual string Para { get; set; }

        /// <summary>
        /// Propriedade com a quantidade de caracteres trocados ou removidos
        /// </summary>
        public virtual int Quantidade { get; set; }


    }
}
