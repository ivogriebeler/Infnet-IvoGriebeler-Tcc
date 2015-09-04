using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Dominio.Entidades.Base
{
    public abstract class Entidade : IEntidade
    {
        public Guid Id { get; set; }
    }
}
