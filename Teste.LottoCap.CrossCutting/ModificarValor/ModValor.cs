using System.Collections.Generic;
using Teste.LottoCap.Domain.Entities;

namespace Teste.LottoCap.CrossCutting.ModificarValor
{
    public class ModValor<T> where T : BaseEntity
    {
        /// <summary>
        /// Método comum para contagem de caracteres
        /// </summary>
        /// <param name="obj">Objeto com as propriedades a serem contadas</param>
        /// <returns>Retorna o objeto e a quantidade</returns>
        public T ModificarValor(T obj)
        {
            int QtdTrocado = 0;
            bool Passou = false;
            if (obj.De.Length >= obj.Para.Length)
            {
                for (int i = 0; i <= obj.De.Length - 1; i++)
                {
                    if (Passou) break;
                    if (i <= obj.Para.Length - 1)
                    {
                        if (obj.De.ToCharArray()[i].ToString().ToUpper() != obj.Para.ToCharArray()[i].ToString().ToUpper())
                        {
                            QtdTrocado++;
                        }
                    }
                    else
                    {
                        int UltimaPos = obj.Para.Length - 1;
                        if (obj.De.ToCharArray()[i].ToString().ToUpper() != obj.Para.ToCharArray()[UltimaPos].ToString().ToUpper())
                        {
                            Passou = true;
                            QtdTrocado++;
                        }
                    };
                }
            }
            else
            {
                for (int i = 0; i <= obj.Para.Length - 1; i++)
                {
                    if (Passou) break;
                    if (i <= obj.De.Length - 1)
                    {
                        if (obj.De.ToCharArray()[i].ToString().ToUpper() != obj.Para.ToCharArray()[i].ToString().ToUpper())
                        {
                            QtdTrocado++;
                        }
                    }
                    else
                    {
                        int UltimaPos = obj.De.Length - 1;
                        if (obj.De.ToCharArray()[UltimaPos].ToString().ToUpper() != obj.Para.ToCharArray()[i].ToString().ToUpper())
                        {
                            Passou = true;
                            QtdTrocado++;
                        }
                    }
                }
            }

            obj.Quantidade = QtdTrocado;

            return obj;
        }

    }
}
