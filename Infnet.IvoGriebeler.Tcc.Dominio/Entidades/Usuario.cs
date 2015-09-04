using Infnet.IvoGriebeler.Tcc.Dominio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public string Email { get; set; }

        public string HashSenha { get; set; }

        public string NomeCompleto { get; set; }

        public int Idade { get; set; }

        public string Observacoes { get; set; }

        public bool Administrador { get; set; }

        public bool Ativo { get; set; }

        public Guid OrganizacaoId { get; set; }
        public virtual Organizacao Organizacao { get; set; }

        public Guid? SerieId { get; set; }
        public virtual Serie Serie { get; set; }
    }
}
