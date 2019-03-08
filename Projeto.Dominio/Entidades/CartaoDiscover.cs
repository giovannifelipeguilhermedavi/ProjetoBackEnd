using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Dominio.Entidades
{
    public class CartaoDiscover : Cartao
    {
        private readonly string _tipoCartao;        

        public CartaoDiscover(string numeroCartao, string bandeira)
            : base(numeroCartao, bandeira)
        {
            _tipoCartao = "DISCOVER";
        }
        public override string TipoCartao => _tipoCartao;
        public override bool ValidarBandeira()
        {
            bool bandeiraValida = false;
            string parametro = string.Empty;
            parametro = NumeroCartao.Substring(0, 4);
            if (parametro.Equals("6011") && NumeroCartao.Length == 16)
            {
                bandeiraValida = true;
            }
            return bandeiraValida;
        }
    }
}
