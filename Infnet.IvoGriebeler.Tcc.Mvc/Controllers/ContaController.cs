using Infnet.IvoGriebeler.Tcc.Mvc.App_Start;
using Infnet.IvoGriebeler.Tcc.Mvc.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infnet.IvoGriebeler.Tcc.Mvc.Controllers
{
    public class ContaController : Controller
    {
        private AplicacaoSignInManager signInManager;
        private UsuarioAplicacaoManager usuarioManager;

        public ContaController()
        {
        }

        public ContaController(AplicacaoSignInManager signInManager, UsuarioAplicacaoManager usuarioManager)
        {
            SignInManager = signInManager;
            UsuarioManager = usuarioManager;
        }

        public AplicacaoSignInManager SignInManager
        {
            get
            {
                return signInManager ?? HttpContext.GetOwinContext().Get<AplicacaoSignInManager>();
            }
            private set
            {
                signInManager = value;
            }
        }

        public UsuarioAplicacaoManager UsuarioManager
        {
            get
            {
                return usuarioManager ?? HttpContext.GetOwinContext().Get<UsuarioAplicacaoManager>();
            }
            private set
            {
                usuarioManager = value;
            }
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel { Email = "max@hgm.com.br", Senha = "max!2015" });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var resultado = SignInManager.PasswordSignIn(model.Email, model.Senha, model.ManterMeLogado, false);
            switch (resultado)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                default:
                    ModelState.AddModelError("", "Tentativa de login inválida.");
                    return View(model);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }

            base.Dispose(disposing);
        }
    }
}