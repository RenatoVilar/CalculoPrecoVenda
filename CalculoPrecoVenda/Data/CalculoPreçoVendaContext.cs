using CalculoPrecoVenda.Data;
using CalculoPrecoVenda.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CalculoPrecoVenda
{
    public class CalculoPreçoVendaContext : DbContext
    {
        public CalculoPreçoVendaContext()
            : base("CalculoPrecoVendaDb")
        {
            //AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
            Database.SetInitializer<CalculoPreçoVendaContext>(null);
        }

        public virtual DbSet<UnidadeFederada> UFs { get; set; }
        public virtual DbSet<Ncm> Ncms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("nvarchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UnidadeFederadaConfiguration());
            modelBuilder.Configurations.Add(new NcmConfiguration());
        }
    }
}
