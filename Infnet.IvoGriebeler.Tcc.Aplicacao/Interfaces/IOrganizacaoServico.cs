using Infnet.IvoGriebeler.Tcc.Aplicacao.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Aplicacao.Interfaces
{
    public interface IOrganizacaoServico
    {
        IList<OrganizacaoDto> ObterTodos();
        OrganizacaoDto ObterPorId(Guid id);
        OrganizacaoDto Adicionar(OrganizacaoDto organizacao);
        OrganizacaoDto Atualizar(OrganizacaoDto organizacao);
        void Excluir(OrganizacaoDto organizacao);
    }
}
