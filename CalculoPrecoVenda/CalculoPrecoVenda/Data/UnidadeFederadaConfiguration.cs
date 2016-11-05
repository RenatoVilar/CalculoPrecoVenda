using CalculoPrecoVenda.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoPrecoVenda.Data
{
    public class UnidadeFederadaConfiguration : EntityTypeConfiguration<UnidadeFederada>
    {
        public UnidadeFederadaConfiguration()
        {
            ToTable("Ufs");
            HasKey(u => u.UfId);

            Property(u => u.NomeUf)
                .IsRequired()
                .HasMaxLength(30);

            Property(u => u.SiglaUf)
                .IsRequired()
                .HasMaxLength(2);

            Property(u => u.ItensFcp)
                .IsRequired()
                .HasMaxLength(300);

        }
    }
}
