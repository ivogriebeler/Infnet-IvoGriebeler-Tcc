using Infnet.IvoGriebeler.Tcc.Dominio.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Aplicacao.Base
{
    public abstract class Servico : IDisposable
    {
        protected readonly IUnitOfWork unitOfWork;

        public Servico(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
