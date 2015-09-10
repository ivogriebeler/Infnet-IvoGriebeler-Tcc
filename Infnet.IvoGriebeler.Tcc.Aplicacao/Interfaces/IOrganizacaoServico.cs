using Infnet.IvoGriebeler.Tcc.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Aplicacao.Interfaces
{
    public interface IOrganizacaoServico
    {
        IList<Organizacao> ObterTodos();
        Organizacao Obter(Guid id);
        void Adicionar(Organizacao organizacao);
        void Atualizar(Organizacao organizacao);
        void Excluir(Organizacao organizacao);
    }
}
