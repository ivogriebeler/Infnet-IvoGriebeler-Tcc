using Infnet.IvoGriebeler.Tcc.Dominio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Dominio.Entidades
{
    public class Exercicio : Entidade
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public int Duracao { get; set; }

        public Guid SerieId { get; set; }
        public virtual Serie Serie { get; set; }
    }
}
