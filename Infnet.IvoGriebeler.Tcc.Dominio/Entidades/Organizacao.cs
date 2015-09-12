using Infnet.IvoGriebeler.Tcc.Dominio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Dominio.Entidades
{
    public class Organizacao : Entidade
    {
        [Required]
        public string Nome { get; set; }

        public IList<Usuario> Usuarios { get; set; }

        public Organizacao()
        {
            Usuarios = new List<Usuario>();
        }
    }
}
