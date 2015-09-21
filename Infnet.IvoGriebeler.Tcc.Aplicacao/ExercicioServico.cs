using Infnet.IvoGriebeler.Tcc.Aplicacao.Base;
using Infnet.IvoGriebeler.Tcc.Aplicacao.Dtos;
using Infnet.IvoGriebeler.Tcc.Aplicacao.Interfaces;
using Infnet.IvoGriebeler.Tcc.Dominio.Entidades;
using Infnet.IvoGriebeler.Tcc.Dominio.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Aplicacao
{
    public class ExercicioServico : Servico, IExercicioServico
    {
        public ExercicioServico(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public ExercicioDto ObterPorId(Guid id)
        {
            var exercicio = unitOfWork.ExercicioRepositorio.ObterPorId(id);
            return exercicio.ToDto();
        }

        public IList<ExercicioDto> ObterTodos()
        {
            var exerciciosDto = unitOfWork.ExercicioRepositorio.ObterTodos()
                .AsEnumerable()
                .Select(e => e.ToDto())
                .ToList();
            return exerciciosDto;
        }

        public ExercicioDto Adicionar(ExercicioDto exercicioDto)
        {
            var exercicio = new Exercicio { Nome = exercicioDto.Nome, Descricao = exercicioDto.Descricao, Duracao = exercicioDto.Duracao };
            unitOfWork.ExercicioRepositorio.Adicionar(exercicio);
            unitOfWork.Salvar();
            exercicioDto.Id = exercicio.Id;
            return exercicioDto;
        }

        public ExercicioDto Atualizar(ExercicioDto exercicioDto)
        {
            var exercicio = unitOfWork.ExercicioRepositorio.ObterPorId(exercicioDto.Id);
            exercicio.Nome = exercicioDto.Nome;
            exercicio.Descricao = exercicioDto.Descricao;
            exercicio.Duracao = exercicioDto.Duracao;
            unitOfWork.ExercicioRepositorio.Atualizar(exercicio);
            unitOfWork.Salvar();
            return exercicio.ToDto();
        }

        public void Excluir(ExercicioDto exercicioDto)
        {
            unitOfWork.ExercicioRepositorio.Excluir(exercicioDto.Id);
            unitOfWork.Salvar();
        }
    }

    public static class ExercicioServicoExtensions
    {
        public static ExercicioDto ToDto(this Exercicio exercicio)
        {
            var exercicioDto = new ExercicioDto
            {
                Id = exercicio.Id,
                Nome = exercicio.Nome,
                Descricao = exercicio.Descricao,
                Duracao = exercicio.Duracao
            };
            return exercicioDto;
        }
    }
}
