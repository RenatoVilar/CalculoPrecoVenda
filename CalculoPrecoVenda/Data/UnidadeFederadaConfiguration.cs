using CalculoPrecoVenda.Model;
using System.Data.Entity.ModelConfiguration;

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
                .HasColumnType("NVARCHAR")
                .HasMaxLength(30);


            Property(u => u.SiglaUf)
                .IsRequired()
                 .HasColumnType("NVARCHAR")
                .HasMaxLength(2);

            Property(u => u.ItensFcp)
                .IsRequired()
                 .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

        }
    }
}
