using Projeto.Dominio.Abstract;
using Projeto.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Dominio.CartaoFactory
{
    public class CartaoDiscoveryFactory : FactoryCartao
    {
        private string _numeroCartao;
        private string _nomeCartao;

        public CartaoDiscoveryFactory(string numeroCartao, string nomeCartao)
        {
            _numeroCartao = numeroCartao;
            _nomeCartao = nomeCartao;
        }
        public override Cartao GetCartao()
        {
            return new CartaoDiscover(_numeroCartao, _nomeCartao);
        }
    }
}
