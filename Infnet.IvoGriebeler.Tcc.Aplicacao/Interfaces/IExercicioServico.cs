using Infnet.IvoGriebeler.Tcc.Aplicacao.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Aplicacao.Interfaces
{
    public interface IExercicioServico
    {
        IList<ExercicioDto> ObterTodos();
        ExercicioDto ObterPorId(Guid id);
        ExercicioDto Adicionar(ExercicioDto exercicio);
        ExercicioDto Atualizar(ExercicioDto exercicio);
        void Excluir(ExercicioDto exercicio);
    }
}
