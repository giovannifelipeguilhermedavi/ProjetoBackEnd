namespace Projeto.Dominio.Entidades
{
    public class CartaoAmex : Cartao
    {
        private readonly string _tipoCartao;        

        public CartaoAmex(string numeroCartao, string bandeira)
            : base(numeroCartao, bandeira)
        {
            _tipoCartao = "AMEX";
        }
        public override string TipoCartao => _tipoCartao;

        public CartaoAmex()
        {}
        public override bool ValidarBandeira()
        {
            bool bandeiraValida = false;
            string parametro = string.Empty;
            parametro = NumeroCartao.Substring(0, 2);
            if ((parametro.Equals("34") || parametro.Equals("37")) && NumeroCartao.Length == 15)
            {
                bandeiraValida = true;
            }
            return bandeiraValida;
        }
    }
}
