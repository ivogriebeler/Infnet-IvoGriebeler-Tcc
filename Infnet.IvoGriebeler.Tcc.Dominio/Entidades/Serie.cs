using Infnet.IvoGriebeler.Tcc.Dominio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Dominio.Entidades
{
    public class Serie : Entidade
    {
        public string Nome { get; set; }

        public IList<Exercicio> Exercicios { get; set; }

        public int Intervalo { get; set; }

        public NivelSerie Nivel { get; set; }

        public Serie()
        {
            Exercicios = new List<Exercicio>();
        }
    }

    public enum NivelSerie
    {
        Facil = 1,
        Medio = 2,
        Dificil = 3
    }
}
