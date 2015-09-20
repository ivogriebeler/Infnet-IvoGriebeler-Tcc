using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Infnet.IvoGriebeler.Tcc.Mvc.Areas.Administracao.Models
{
    public class ExercicioModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public string Imagem { get; set; }

        [Required]
        [Display(Name = "Duração")]
        public int Duracao { get; set; }
    }
}