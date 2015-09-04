using System.Web.Mvc;

namespace Infnet.IvoGriebeler.Tcc.Mvc.Areas.Administracao
{
    public class AdministracaoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administracao";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administracao_default",
                "Administracao/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}