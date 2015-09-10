using Infnet.IvoGriebeler.Tcc.Aplicacao.Base;
using Infnet.IvoGriebeler.Tcc.Aplicacao.Interfaces;
using Infnet.IvoGriebeler.Tcc.Dominio.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infnet.IvoGriebeler.Tcc.Dominio.Entidades;

namespace Infnet.IvoGriebeler.Tcc.Aplicacao
{
    public class OrganizacaoServico : Servico, IOrganizacaoServico
    {
        public OrganizacaoServico(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Organizacao Obter(Guid id)
        {
            return unitOfWork.OrganizacaoRepositorio.ObterPorId(id);
        }

        public IList<Organizacao> ObterTodos()
        {
            return unitOfWork.OrganizacaoRepositorio.ObterTodos().ToList();
        }

        public void Adicionar(Organizacao organizacao)
        {
            unitOfWork.OrganizacaoRepositorio.Adicionar(organizacao);
            unitOfWork.Salvar();
        }

        public void Atualizar(Organizacao organizacao)
        {
            unitOfWork.OrganizacaoRepositorio.Atualizar(organizacao);
            unitOfWork.Salvar();
        }

        public void Excluir(Organizacao organizacao)
        {
            unitOfWork.OrganizacaoRepositorio.Excluir(organizacao.Id);
            unitOfWork.Salvar();
        }
    }
}
