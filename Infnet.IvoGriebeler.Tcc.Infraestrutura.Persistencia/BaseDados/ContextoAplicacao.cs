using Infnet.IvoGriebeler.Tcc.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Infraestrutura.Persistencia.BaseDados
{
    public class ContextoAplicacao : DbContext
    {
        public ContextoAplicacao()
            : base("ContextoAplicacao")
        {
        }

        public DbSet<ExercicioRealizado> ExercicioRealizado { get; set; }
        public DbSet<Exercicio> Exercicio { get; set; }
        public DbSet<Organizacao> Organizacao { get; set; }
        public DbSet<Serie> Serie { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public static void SetDatabaseInitializer()
        {
            Database.SetInitializer(new ContextoAplicacaoDatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExercicioRealizado>()
                .Property(er => er.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            modelBuilder.Entity<Exercicio>()
                .Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            modelBuilder.Entity<Organizacao>()
                .Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            modelBuilder.Entity<Serie>()
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public static ContextoAplicacao Criar()
        {
            return new ContextoAplicacao();
        }
    }
}
