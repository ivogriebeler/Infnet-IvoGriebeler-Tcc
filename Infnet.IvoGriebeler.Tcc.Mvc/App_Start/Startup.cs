using Infnet.IvoGriebeler.Tcc.Infraestrutura.Persistencia.BaseDados;
using Infnet.IvoGriebeler.Tcc.Mvc.App_Start;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infnet.IvoGriebeler.Tcc.Mvc
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ContextoAplicacao.Criar);
            app.CreatePerOwinContext<UsuarioAplicacaoManager>(UsuarioAplicacaoManager.Criar);
            app.CreatePerOwinContext<AplicacaoSignInManager>(AplicacaoSignInManager.Criar);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Conta/Login"),
                Provider = new CookieAuthenticationProvider()
            });
        }
    }
}