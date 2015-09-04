using Infnet.IvoGriebeler.Tcc.Dominio.Repositorios;
using Infnet.IvoGriebeler.Tcc.Dominio.UnitOfWork;
using Infnet.IvoGriebeler.Tcc.Infraestrutura.Persistencia.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Infraestrutura.Persistencia.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext db;

        public UnitOfWork(DbContext db)
        {
            this.db = db;
        }

        private IExercicioRealizadoRepositorio exercicioRealizadoRepositorio;
        public IExercicioRealizadoRepositorio ExercicioRealizadoRepositorio
        {
            get { return exercicioRealizadoRepositorio ?? (exercicioRealizadoRepositorio = new ExercicioRealizadoRepositorio(db)); }
        }

        private IExercicioRepositorio exercicioRepositorio;
        public IExercicioRepositorio ExercicioRepositorio
        {
            get { return exercicioRepositorio ?? (exercicioRepositorio = new ExercicioRepositorio(db)); }
        }

        private IOrganizacaoRepositorio organizacaoRepositorio;
        public IOrganizacaoRepositorio OrganizacaoRepositorio
        {
            get { return organizacaoRepositorio ?? (organizacaoRepositorio = new OrganizacaoRepositorio(db)); }
        }

        private ISerieRepositorio serieRepositorio;
        public ISerieRepositorio SerieRepositorio
        {
            get { return serieRepositorio ?? (serieRepositorio = new SerieRepositorio(db)); }
        }

        private IUsuarioRepositorio usuarioRepositorio;
        public IUsuarioRepositorio UsuarioRepositorio
        {
            get { return usuarioRepositorio ?? (usuarioRepositorio = new UsuarioRepositorio(db)); }
        }

        public void Salvar()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
