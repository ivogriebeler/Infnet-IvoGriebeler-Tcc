using Infnet.IvoGriebeler.Tcc.Dominio.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Dominio.Repositorios.Base
{
    public interface IRepositorio<TEntidade> where TEntidade : class, IEntidade
    {
        TEntidade ObterPorId(Guid id);
        IQueryable<TEntidade> ObterTodos();
        void Adicionar(TEntidade entidade);
        void Atualizar(TEntidade entidade);
        void Excluir(Guid id);
    }
}
