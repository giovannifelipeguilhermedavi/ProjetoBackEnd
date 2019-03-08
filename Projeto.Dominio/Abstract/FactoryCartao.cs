using Projeto.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Dominio.Abstract
{
    public abstract class FactoryCartao
    {
        public abstract Cartao GetCartao();
    }
}
