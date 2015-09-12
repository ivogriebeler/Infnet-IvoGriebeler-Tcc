using AutoMapper;
using Infnet.IvoGriebeler.Tcc.Aplicacao.Dtos;
using Infnet.IvoGriebeler.Tcc.Dominio.Entidades;
using Infnet.IvoGriebeler.Tcc.Mvc.Areas.Administracao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infnet.IvoGriebeler.Tcc.Mvc
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<OrganizacaoModel, OrganizacaoDto>()
                .ReverseMap();
            Mapper.CreateMap<AdicionarOrganizacaoModel, OrganizacaoDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();

            Mapper.AssertConfigurationIsValid();
        }
    }
}