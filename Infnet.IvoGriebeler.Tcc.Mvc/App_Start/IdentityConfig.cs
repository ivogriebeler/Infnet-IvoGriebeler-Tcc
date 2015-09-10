using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Infnet.IvoGriebeler.Tcc.Infraestrutura.Persistencia.BaseDados;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Infnet.IvoGriebeler.Tcc.Dominio.Entidades;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace Infnet.IvoGriebeler.Tcc.Mvc.App_Start
{
    public class AplicacaoSignInManager : SignInManager<UsuarioAplicacao, Guid>
    {
        public AplicacaoSignInManager(UsuarioAplicacaoManager usuarioManager, IAuthenticationManager authenticationManager)
            : base(usuarioManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(UsuarioAplicacao user)
        {
            return user.GenerateUserIdentityAsync((UsuarioAplicacaoManager)UserManager);
        }

        public static AplicacaoSignInManager Criar(IdentityFactoryOptions<AplicacaoSignInManager> options, IOwinContext context)
        {
            return new AplicacaoSignInManager(context.GetUserManager<UsuarioAplicacaoManager>(), context.Authentication);
        }
    }

    public class UsuarioAplicacaoManager : UserManager<UsuarioAplicacao, Guid>
    {
        public UsuarioAplicacaoManager(IUserStore<UsuarioAplicacao, Guid> store)
            : base(store)
        {
        }

        public static UsuarioAplicacaoManager Criar(IdentityFactoryOptions<UsuarioAplicacaoManager> options, IOwinContext context)
        {
            var manager = new UsuarioAplicacaoManager(new UsuarioAplicacaoStore(context.Get<ContextoAplicacao>()));

            manager.UserValidator = new UserValidator<UsuarioAplicacao, Guid>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            manager.EmailService = new EmailService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<UsuarioAplicacao, Guid>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }
    }

    public class UsuarioAplicacaoStore : IUserStore<UsuarioAplicacao, Guid>, IUserPasswordStore<UsuarioAplicacao, Guid>, IUserLockoutStore<UsuarioAplicacao, Guid>, IUserTwoFactorStore<UsuarioAplicacao, Guid>
    {
        private DbContext db;
        private DbSet<Usuario> usuarioSet;

        public UsuarioAplicacaoStore(DbContext db)
        {
            this.db = db;
            this.usuarioSet = db.Set<Usuario>();
        }

        public Task CreateAsync(UsuarioAplicacao user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(UsuarioAplicacao user)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioAplicacao> FindByIdAsync(Guid userId)
        {
            var usuario = await usuarioSet.FindAsync(userId);
            if (usuario == null || !usuario.Ativo)
                return null;

            return new UsuarioAplicacao { Id = usuario.Id, UserName = usuario.Email, HashSenha = usuario.HashSenha, Administrador = usuario.Administrador };
        }

        public async Task<UsuarioAplicacao> FindByNameAsync(string userName)
        {
            var usuario = await usuarioSet.SingleOrDefaultAsync(u => u.Email == userName);
            if (usuario == null || !usuario.Ativo)
                return null;

            return new UsuarioAplicacao { Id = usuario.Id, UserName = usuario.Email, HashSenha = usuario.HashSenha, Administrador = usuario.Administrador };
        }

        public async Task<string> GetPasswordHashAsync(UsuarioAplicacao user)
        {
            var usuario = await usuarioSet.SingleOrDefaultAsync(u => u.Id == user.Id);
            if (usuario == null)
                return null;

            return usuario.HashSenha;
        }

        public Task<bool> HasPasswordAsync(UsuarioAplicacao user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(UsuarioAplicacao user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UsuarioAplicacao user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(UsuarioAplicacao user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(UsuarioAplicacao user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(UsuarioAplicacao user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(UsuarioAplicacao user)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(UsuarioAplicacao user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(UsuarioAplicacao user)
        {
            return Task.FromResult(false);
        }

        public Task SetLockoutEnabledAsync(UsuarioAplicacao user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetTwoFactorEnabledAsync(UsuarioAplicacao user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(UsuarioAplicacao user)
        {
            return Task.FromResult(false);
        }
    }

    public class UsuarioAplicacao : IUser<Guid>
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string HashSenha { get; set; }

        public bool Administrador { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UsuarioAplicacao, Guid> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            if (Administrador)
                userIdentity.AddClaim(new Claim(ClaimTypes.Role, "Administrador"));

            return userIdentity;
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return Task.FromResult(0);
        }
    }
}