using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoPrecoVenda.Model
{
    public class UnidadeFederada
    {
        public int UnidadeFederadaId { get; set; }
        public string NomeUf { get; set; }
        public string Sigla { get; set; }
        public double AliquotaInterna { get; set; }
        public double AliquotaFcp { get; set; }
        public string ItensFcp { get; set; }
    }
}

