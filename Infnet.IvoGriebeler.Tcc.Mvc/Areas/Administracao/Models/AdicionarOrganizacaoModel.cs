using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Infnet.IvoGriebeler.Tcc.Mvc.Areas.Administracao.Models
{
    public class AdicionarOrganizacaoModel
    {
        [Required]
        public string Nome { get; set; }
    }
}