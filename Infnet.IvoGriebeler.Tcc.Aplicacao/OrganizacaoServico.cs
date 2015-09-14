using Infnet.IvoGriebeler.Tcc.Aplicacao.Base;
using Infnet.IvoGriebeler.Tcc.Aplicacao.Interfaces;
using Infnet.IvoGriebeler.Tcc.Dominio.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infnet.IvoGriebeler.Tcc.Dominio.Entidades;
using Infnet.IvoGriebeler.Tcc.Aplicacao.Dtos;

namespace Infnet.IvoGriebeler.Tcc.Aplicacao
{
    public class OrganizacaoServico : Servico, IOrganizacaoServico
    {
        public OrganizacaoServico(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public OrganizacaoDto ObterPorId(Guid id)
        {
            var organizacao = unitOfWork.OrganizacaoRepositorio.ObterPorId(id);
            return organizacao.ToDto();
        }

        public IList<OrganizacaoDto> ObterTodos()
        {
            var organizacoesDto = unitOfWork.OrganizacaoRepositorio.ObterTodos()
                .AsEnumerable()
                .Select(o => o.ToDto())
                .ToList();
            return organizacoesDto;
        }

        public OrganizacaoDto Adicionar(OrganizacaoDto organizacaoDto)
        {
            var organizacao = new Organizacao { Nome = organizacaoDto.Nome };
            unitOfWork.OrganizacaoRepositorio.Adicionar(organizacao);
            unitOfWork.Salvar();
            organizacaoDto.Id = organizacao.Id;
            return organizacaoDto;
        }

        public OrganizacaoDto Atualizar(OrganizacaoDto organizacaoDto)
        {
            var organizacao = unitOfWork.OrganizacaoRepositorio.ObterPorId(organizacaoDto.Id);
            organizacao.Nome = organizacaoDto.Nome;
            unitOfWork.OrganizacaoRepositorio.Atualizar(organizacao);
            unitOfWork.Salvar();
            return organizacao.ToDto();
        }

        public void Excluir(OrganizacaoDto organizacaoDto)
        {
            unitOfWork.OrganizacaoRepositorio.Excluir(organizacaoDto.Id);
            unitOfWork.Salvar();
        }
    }

    public static class OrganizacaoServicoExtensions
    {
        public static OrganizacaoDto ToDto(this Organizacao organizacao)
        {
            var organiacaoDto = new OrganizacaoDto
            {
                Id = organizacao.Id,
                Nome = organizacao.Nome
            };
            return organiacaoDto;
        }
    }
}
