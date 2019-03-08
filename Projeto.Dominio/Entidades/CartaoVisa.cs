namespace Projeto.Dominio.Entidades
{
    public class CartaoVisa : Cartao
    {
        private readonly string _tipoCartao;


        public CartaoVisa(string numeroCartao,string nomeCartao)
            :base(numeroCartao,nomeCartao)
        {
            _tipoCartao = "VISA";
        }
        public override string TipoCartao => _tipoCartao;

        public override bool ValidarBandeira()
        {
            bool bandeiraValida = false;
            string parametro = string.Empty;
            parametro = NumeroCartao.Substring(0, 1);
            if (parametro.Equals("4") && (NumeroCartao.Length == 13 || NumeroCartao.Length == 16))
            {
                bandeiraValida = true;
            }
            return bandeiraValida;
        }
    }
}
