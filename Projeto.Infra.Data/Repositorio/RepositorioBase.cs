using Projeto.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Infra.Data.Repositorio
{
    public class RepositorioBase<T> : ICartaoBase<T> where T : class
    {
        public int[] validarCartao(string numeroCartao)
        {
            string resultado = string.Empty;
            string cartaoInvertido = string.Empty;
            int digito = 0;
            int[] cartaoValorDobrado = null;
            try
            {
                cartaoInvertido = new string(numeroCartao.Reverse().ToArray());

                digito = Convert.ToInt32(cartaoInvertido.Substring(0, 1));

                cartaoValorDobrado = new int[cartaoInvertido.Length];

                if (digito > 9)
                {
                    cartaoValorDobrado[0] = Convert.ToInt32(digito.ToString().Substring(0, 1)) + Convert.ToInt32(digito.ToString().Substring(1, 1));
                }
                else
                    cartaoValorDobrado[0] = digito;

                for (int i = 1; i < cartaoInvertido.Length; i++)
                {
                    cartaoValorDobrado[i] = cartaoValorDobrado[i] * 2;
                    i++;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return cartaoValorDobrado;
        }
    }
}
