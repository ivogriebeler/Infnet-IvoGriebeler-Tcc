using Infnet.IvoGriebeler.Tcc.Dominio.Entidades.Base;
using Infnet.IvoGriebeler.Tcc.Dominio.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Infraestrutura.Persistencia.Repositorios.Base
{
    public abstract class Repositorio<TEntidade> : IRepositorio<TEntidade> where TEntidade : Entidade
    {
        private readonly DbContext db;

        public Repositorio(DbContext db)
        {
            this.db = db;
        }

        public TEntidade ObterPorId(Guid id)
        {
            return db.Set<TEntidade>().Find(id);
        }

        public IQueryable<TEntidade> ObterTodos()
        {
            return db.Set<TEntidade>().AsQueryable();
        }

        public void Adicionar(TEntidade entidade)
        {
            db.Set<TEntidade>().Add(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            db.Set<TEntidade>().Attach(entidade);
            db.Entry(entidade).State = EntityState.Modified;
        }

        public void Excluir(Guid id)
        {
            var entidade = ObterPorId(id);

            if (db.Entry(entidade).State == EntityState.Detached)
                db.Set<TEntidade>().Attach(entidade);

            db.Set<TEntidade>().Remove(entidade);
        }
    }
}
