using Infnet.IvoGriebeler.Tcc.Dominio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Dominio.Entidades
{
    public class ExercicioRealizado : Entidade
    {
        public Guid ExercicioId { get; set; }
        public virtual Exercicio Exercicio { get; set; }

        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public DateTime DataHora { get; set; }
    }
}
