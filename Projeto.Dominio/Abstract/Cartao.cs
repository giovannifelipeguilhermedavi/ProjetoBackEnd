using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Dominio.Entidades
{
    public abstract class Cartao
    {

        public abstract string TipoCartao { get; }

        public string MyProperty { get; set; }
        public string NumeroCartao { get; set; }
        public string Bandeira { get; set; }        

        public Cartao() { }
        public Cartao(string numeroCartao, string bandeira)
        {
            NumeroCartao = numeroCartao;
            bandeira = Bandeira;
        }

        public abstract bool ValidarBandeira();
        public bool validarCartao()
        {
            bool cartaoValido = false;
            int digito = 0;
            int[] cartaoValorDobrado = null;
            try
            {
                string[] cartaoInvertido = TransformarNumeroInvertidoArray(new string(NumeroCartao.Reverse().ToArray()));
                digito = Convert.ToInt32(cartaoInvertido[0]);
                cartaoValorDobrado = new int[cartaoInvertido.Length];
                if (digito > 9)
                { cartaoValorDobrado[0] = Convert.ToInt32(digito.ToString().Substring(0, 1)) + Convert.ToInt32(digito.ToString().Substring(1, 1)); }
                else
                    cartaoValorDobrado[0] = digito;

                int contador = 1;
                int soma = 0;

                for (int i = 0; i < cartaoInvertido.Length; i++)
                {
                    if (i > 0)
                    {
                        if (i == contador)
                        {
                            cartaoValorDobrado[i] = Convert.ToInt32(cartaoInvertido[i]) + Convert.ToInt32(cartaoInvertido[i]);
                            contador = contador + 2;
                            if (cartaoValorDobrado[i] > 9)
                            { cartaoValorDobrado[i] = Convert.ToInt32(cartaoValorDobrado[i]) - 9; }
                        }
                        else
                        { cartaoValorDobrado[i] = Convert.ToInt32(cartaoInvertido[i]); }
                    }
                    soma = soma + cartaoValorDobrado[i];
                }
                cartaoValido = soma % 10 == 0 ? true : false;
            }
            catch
            {
                throw;
            }
            return cartaoValido;
        }

        private string[] TransformarNumeroInvertidoArray(string numeroInvertido)
        {
            string[] arrayInvertido = new string[numeroInvertido.Length];
            for (int i = 0; i < numeroInvertido.Length; i++)
            {
                arrayInvertido[i] = numeroInvertido[i].ToString();
            }
            return arrayInvertido;
        }
    }
}
