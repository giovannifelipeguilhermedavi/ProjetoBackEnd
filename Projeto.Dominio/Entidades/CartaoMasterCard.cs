using System;

namespace Projeto.Dominio.Entidades
{
    public class CartaoMasterCard : Cartao
    {
        private readonly string _tipoCartao;

       public CartaoMasterCard(string numeroCartao, string nomeCartao)
            : base(numeroCartao, nomeCartao)
        {
            _tipoCartao = "MASTERCARD";
        }

        public override string TipoCartao => _tipoCartao;

        public override bool ValidarBandeira()
        {
            bool bandeiraValida = false;
            string parametro = string.Empty;
            parametro = NumeroCartao.Substring(0, 2);
            if ((Convert.ToInt32(parametro) >= 51 && Convert.ToInt32(parametro) <= 55) && NumeroCartao.Length == 16)
            {
                bandeiraValida = true;
            }
            return bandeiraValida;
        }
    }
}
