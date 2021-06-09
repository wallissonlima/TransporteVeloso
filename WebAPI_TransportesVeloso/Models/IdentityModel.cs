using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace WebAPI_TransportesVeloso.Models
{
    // É possível adicionar dados do perfil do usuário adicionando mais propriedades na sua classe ApplicationUser, visite https://go.microsoft.com/fwlink/?LinkID=317594 para obter mais informações.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Observe que o authenticationType deve corresponder àquele definido em CookieAuthenticationOptions.AuthenticationType
            // Observe que o authenticationType deve corresponder àquele definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Adicionar declarações de usuário personalizado aqui
            return userIdentity;
        }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Se estiver utilizando Migration. 
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

            /*Acesso a instrução SQL gerada pelo Entity Framework.
             * Irá escrever a sintaxe SQL na janela de Debug/saída.
            * Como é esperado um Delegate, o valor a ser passado, pode ser através de uma expressão Lambda.
                         * Somente deve ser processado em modo DEBUG
                         */
#if DEBUG
            Database.Log = d => System.Diagnostics.Debug.WriteLine(d);
            var teste = Database.Log;
#endif
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // the all important base class call! Add this line to make your problems go away.
            base.OnModelCreating(modelBuilder);
        }
        //Extende Micrososft.AspNet.Identity.EntityFramework
        public virtual DbSet<Veiculo> AspNetVeiculo { get; set; }
        public virtual DbSet<TipoVeiculo> AspNetTipoVeiculo { get; set; }
        public virtual DbSet<Manutencao> AspNetManutencao { get; set; }
        public virtual DbSet<TipoManutencao> AspNetTipoManutencao { get; set; }
        public virtual DbSet<Peca> AspNetPeca { get; set; }
        public virtual DbSet<MaoDeObra> AspNetMaoDeObra { get; set; }
        public virtual DbSet<Contrato> AspNetContrato { get; set; }
        public virtual DbSet<ContratoVeiculo> AspNetContratoVeiculo { get; set; }
        public virtual DbSet<Viagem> AspNetViagem { get; set; }
        public virtual DbSet<Itinerario> AspNetItinerario { get; set; }
        public virtual DbSet<Usuario> AspNetUsuario { get; set; }
        public virtual DbSet<Consumo> AspNetConsumo { get; set; }
        public virtual DbSet<PerfilUsuario> PerfilUsuarios { get; set; }

    }
}