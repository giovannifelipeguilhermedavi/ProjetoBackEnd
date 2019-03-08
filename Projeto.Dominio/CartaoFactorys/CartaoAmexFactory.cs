using Projeto.Dominio.Abstract;
using Projeto.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Dominio.CartaoFactorys
{
    public class CartaoAmexFactory : FactoryCartao
    {
        private string _numeroCartao;
        private string _nomeCartao;

        public CartaoAmexFactory(string numeroCartao, string nomeCartao)
        {
            _numeroCartao = numeroCartao;
            _nomeCartao = nomeCartao;
        }
        public override Cartao GetCartao()
        {
            return new CartaoAmex(_numeroCartao, _nomeCartao);

        }
    }
}
