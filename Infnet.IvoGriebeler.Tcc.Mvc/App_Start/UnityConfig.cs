using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Infnet.IvoGriebeler.Tcc.Infraestrutura.Persistencia.BaseDados;
using System.Data.Entity;
using Infnet.IvoGriebeler.Tcc.Dominio.UnitOfWork;
using Infnet.IvoGriebeler.Tcc.Aplicacao.Interfaces;
using Infnet.IvoGriebeler.Tcc.Aplicacao;
using Infnet.IvoGriebeler.Tcc.Infraestrutura.Persistencia.UnitOfWork;

namespace Infnet.IvoGriebeler.Tcc.Mvc.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<DbContext, ContextoAplicacao>();

            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterType<IExercicioRealizadoServico, ExercicioRealizadoServico>();
            container.RegisterType<IExercicioServico, ExercicioServico>();
            container.RegisterType<IOrganizacaoServico, OrganizacaoServico>();
            container.RegisterType<ISerieServico, SerieServico>();
            container.RegisterType<IUsuarioServico, UsuarioServico>();
        }
    }
}
