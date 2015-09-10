using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Infnet.IvoGriebeler.Tcc.Dominio.Entidades;
using Infnet.IvoGriebeler.Tcc.Infraestrutura.Persistencia.BaseDados;
using Infnet.IvoGriebeler.Tcc.Aplicacao.Interfaces;

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
            return View(servico.ObterTodos());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Organizacao organizacao = servico.Obter(id.Value);
            if (organizacao == null)
            {
                return HttpNotFound();
            }

            return View(organizacao);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome")] Organizacao organizacao)
        {
            if (ModelState.IsValid)
            {
                servico.Adicionar(organizacao);
                return RedirectToAction("Index");
            }

            return View(organizacao);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Organizacao organizacao = servico.Obter(id.Value);
            if (organizacao == null)
            {
                return HttpNotFound();
            }

            return View(organizacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Organizacao organizacao)
        {
            if (ModelState.IsValid)
            {
                servico.Atualizar(organizacao);
                return RedirectToAction("Index");
            }

            return View(organizacao);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Organizacao organizacao = servico.Obter(id.Value);
            if (organizacao == null)
            {
                return HttpNotFound();
            }

            return View(organizacao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var organizacao = servico.Obter(id);
            servico.Excluir(organizacao);

            return RedirectToAction("Index");
        }
    }
}
