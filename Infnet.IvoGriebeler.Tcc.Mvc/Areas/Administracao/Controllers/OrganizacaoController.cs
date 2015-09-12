using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Infnet.IvoGriebeler.Tcc.Aplicacao.Interfaces;
using Infnet.IvoGriebeler.Tcc.Mvc.Areas.Administracao.Models;
using AutoMapper;
using Infnet.IvoGriebeler.Tcc.Aplicacao.Dtos;

namespace Infnet.IvoGriebeler.Tcc.Mvc.Areas.Administracao.Controllers
{
    public class OrganizacaoController : Controller
    {
        private IOrganizacaoServico servico;

        public OrganizacaoController(IOrganizacaoServico servico)
        {
            this.servico = servico;
        }

        public ActionResult Index()
        {
            var organizacoes = servico.ObterTodos();
            var model = Mapper.Map<IList<OrganizacaoModel>>(organizacoes);
            return View(model);
        }

        public ActionResult Detalhes(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var organizacao = servico.ObterPorId(id.Value);
            if (organizacao == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Map<OrganizacaoModel>(organizacao);
            return View(model);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(AdicionarOrganizacaoModel model)
        {
            if (ModelState.IsValid)
            {
                var organizacao = Mapper.Map<OrganizacaoDto>(model);
                servico.Adicionar(organizacao);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Editar(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var organizacao = servico.ObterPorId(id.Value);
            if (organizacao == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Map<OrganizacaoModel>(organizacao);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(OrganizacaoModel model)
        {
            if (ModelState.IsValid)
            {
                var organizacao = Mapper.Map<OrganizacaoDto>(model);
                servico.Atualizar(organizacao);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Excluir(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var organizacao = servico.ObterPorId(id.Value);
            if (organizacao == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Map<OrganizacaoModel>(organizacao);
            return View(model);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirPost(Guid id)
        {
            var organizacao = servico.ObterPorId(id);
            servico.Excluir(organizacao);

            return RedirectToAction("Index");
        }
    }
}
