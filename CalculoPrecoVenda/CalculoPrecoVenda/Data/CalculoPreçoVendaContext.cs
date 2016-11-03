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
            //AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
            AppDomain.CurrentDomain.SetData("DataDirectory", @"C:\Users\Renato.ALEGRANAUTICA\Documents\Visual Studio 2015\Projects\CalculoPrecoVenda\CalculoPrecoVenda\CalculoPrecoVenda\Data");
            Database.SetInitializer<CalculoPreçoVendaContext>(new CreateDatabaseIfNotExists<CalculoPreçoVendaContext>());

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
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UnidadeFederadaConfiguration());
            modelBuilder.Configurations.Add(new NcmConfiguration());
        }
    }
}
