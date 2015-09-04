using Infnet.IvoGriebeler.Tcc.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Dominio.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IExercicioRealizadoRepositorio ExercicioRealizadoRepositorio { get; }
        IExercicioRepositorio ExercicioRepositorio { get; }
        IOrganizacaoRepositorio OrganizacaoRepositorio { get; }
        ISerieRepositorio SerieRepositorio { get; }
        IUsuarioRepositorio UsuarioRepositorio { get; }

        void Salvar();
    }
}
