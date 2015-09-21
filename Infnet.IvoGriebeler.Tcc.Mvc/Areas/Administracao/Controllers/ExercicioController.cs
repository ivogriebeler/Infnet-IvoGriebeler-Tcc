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
    [Authorize(Roles = "Administrador")]
    public class ExercicioController : Controller
    {
        private IExercicioServico servico;

        public ExercicioController(IExercicioServico servico)
        {
            this.servico = servico;
        }

        public ActionResult Index()
        {
            var exercicios = servico.ObterTodos();
            var model = Mapper.Map<IList<ExercicioModel>>(exercicios);
            return View(model);
        }

        public ActionResult Detalhes(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var exercicio = servico.ObterPorId(id.Value);
            if (exercicio == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Map<ExercicioModel>(exercicio);
            return View(model);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(ExercicioModel model)
        {
            if (ModelState.IsValid)
            {
                var exercicio = Mapper.Map<ExercicioDto>(model);
                servico.Adicionar(exercicio);
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

            var exercicio = servico.ObterPorId(id.Value);
            if (exercicio == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Map<ExercicioModel>(exercicio);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ExercicioModel model)
        {
            if (ModelState.IsValid)
            {
                var exercicio = Mapper.Map<ExercicioDto>(model);
                servico.Atualizar(exercicio);
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

            var exercicio = servico.ObterPorId(id.Value);
            if (exercicio == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Map<ExercicioModel>(exercicio);
            return View(model);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirPost(Guid id)
        {
            var exercicio = servico.ObterPorId(id);
            servico.Excluir(exercicio);

            return RedirectToAction("Index");
        }
    }
}
