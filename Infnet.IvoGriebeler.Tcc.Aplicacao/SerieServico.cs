﻿using Infnet.IvoGriebeler.Tcc.Aplicacao.Base;
using Infnet.IvoGriebeler.Tcc.Aplicacao.Interfaces;
using Infnet.IvoGriebeler.Tcc.Dominio.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Aplicacao
{
    public class SerieServico : Servico, ISerieServico
    {
        public SerieServico(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
