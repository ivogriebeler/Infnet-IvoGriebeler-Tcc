﻿using Infnet.IvoGriebeler.Tcc.Dominio.Entidades;
using Infnet.IvoGriebeler.Tcc.Dominio.Repositorios;
using Infnet.IvoGriebeler.Tcc.Infraestrutura.Persistencia.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Infraestrutura.Persistencia.Repositorios
{
    public class SerieRepositorio : Repositorio<Serie>, ISerieRepositorio
    {
        public SerieRepositorio(DbContext db)
            : base(db)
        {
        }
    }
}
