using Projeto.Dominio.Abstract;
using Projeto.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Dominio.CartaoFactory
{
    public class CartaoVisaFactory : FactoryCartao
    {
        private string _numeroCartao;
        private string _nomeCartao;

        public CartaoVisaFactory(string numeroCartao, string nomeCartao)
        {
            _numeroCartao = numeroCartao;
            _nomeCartao = nomeCartao;
        }
        public override Cartao GetCartao()
        {
            return new CartaoVisa(_numeroCartao, _nomeCartao);
        }
    }
}
