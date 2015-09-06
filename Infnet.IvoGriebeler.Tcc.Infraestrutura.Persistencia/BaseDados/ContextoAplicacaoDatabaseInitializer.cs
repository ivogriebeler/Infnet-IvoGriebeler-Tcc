using Infnet.IvoGriebeler.Tcc.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Infraestrutura.Persistencia.BaseDados
{
    public class ContextoAplicacaoDatabaseInitializer : DropCreateDatabaseIfModelChanges<ContextoAplicacao>
    {
        protected override void Seed(ContextoAplicacao context)
        {
            var organizacaoInfnet = new Organizacao
            {
                Nome = "Infnet"
            };
            context.Organizacao.Add(organizacaoInfnet);

            var usuarioAdmin = new Usuario
            {
                NomeCompleto = "Administrador",
                Email = "admin@local",
                HashSenha = System.Web.Helpers.Crypto.HashPassword("admin!2015"),
                Ativo = true,
                Administrador = true
            };
            organizacaoInfnet.Usuarios.Add(usuarioAdmin);

            var serieCostas = new Serie
            {
                Nome = "Costas",
                Intervalo = 60,
                Nivel = NivelSerie.Medio
            };
            context.Serie.Add(serieCostas);

            var exercicioCostas1 = new Exercicio
            {
                Nome = "Costas 1",
                Descricao = "Alongamento de Costas 1",
                Duracao = 2
            };
            serieCostas.Exercicios.Add(exercicioCostas1);

            var exercicioCostas2 = new Exercicio
            {
                Nome = "Costas 2",
                Descricao = "Alongamento de Costas 2",
                Duracao = 3
            };
            serieCostas.Exercicios.Add(exercicioCostas2);

            var exercicioCostas3 = new Exercicio
            {
                Nome = "Costas 3",
                Descricao = "Alongamento de Costas 3",
                Duracao = 1
            };
            serieCostas.Exercicios.Add(exercicioCostas3);

            var organizacaoHgm = new Organizacao
            {
                Nome = "HGM Sistemas"
            };
            context.Organizacao.Add(organizacaoHgm);

            var usuarioIvo = new Usuario
            {
                NomeCompleto = "Ivo Griebeler",
                Email = "ivo@hgm.com.br",
                HashSenha = System.Web.Helpers.Crypto.HashPassword("ivo!2015"),
                Ativo = true,
                Serie = serieCostas
            };
            organizacaoHgm.Usuarios.Add(usuarioIvo);

            var serieJoelho = new Serie
            {
                Nome = "Joelho",
                Intervalo = 120,
                Nivel = NivelSerie.Facil
            };
            context.Serie.Add(serieJoelho);

            var exercicioJoelho1 = new Exercicio
            {
                Nome = "Joelho 1",
                Descricao = "Alongamento de joelho 1",
                Duracao = 4
            };
            serieJoelho.Exercicios.Add(exercicioJoelho1);

            var exercicioJoelho2 = new Exercicio
            {
                Nome = "Joelho 2",
                Descricao = "Alongamento de joelho 2",
                Duracao = 2
            };
            serieJoelho.Exercicios.Add(exercicioJoelho2);

            var usuarioMax = new Usuario
            {
                NomeCompleto = "Max Bündchen",
                Email = "max@hgm.com.br",
                HashSenha = System.Web.Helpers.Crypto.HashPassword("max!2015"),
                Ativo = true,
                Serie = serieJoelho
            };
            organizacaoHgm.Usuarios.Add(usuarioMax);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
