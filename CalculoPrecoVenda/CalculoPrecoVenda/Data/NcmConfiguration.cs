using CalculoPrecoVenda.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoPrecoVenda.Data
{
    public class NcmConfiguration : EntityTypeConfiguration<Ncm>
    {
        public NcmConfiguration()
        {
            HasKey(n => n.NcmId);

            Property(u => u.CodNcm)
               .IsRequired()
               .HasMaxLength(10);

            Property(u => u.NomeNcm)
               .IsRequired()
               .HasMaxLength(150);
        }
    }
}
