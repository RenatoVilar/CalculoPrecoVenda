using CalculoPrecoVenda.Data;
using CalculoPrecoVenda.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CalculoPrecoVenda
{
    public class CalculoPreçoVendaContext : DbContext
    {
        public CalculoPreçoVendaContext()
            : base("CalculoPrecoVendaDb")
        {

        }

        private DbSet<UnidadeFederada> UFs { get; set; }

        public DbSet<Ncm> Ncms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UnidadeFederadaConfiguration());
            modelBuilder.Configurations.Add(new NcmConfiguration());
        }
    }
}
