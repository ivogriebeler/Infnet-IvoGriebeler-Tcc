using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Infnet.IvoGriebeler.Tcc.Mvc.Areas.Administracao.Models
{
    public class OrganizacaoModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}