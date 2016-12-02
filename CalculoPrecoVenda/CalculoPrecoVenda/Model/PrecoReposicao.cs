using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoPrecoVenda.Model
{
    class PrecoReposicao
    {
        public decimal ValorNota { get; set; }
        public decimal Icms { get; set; }
        public decimal ValorLiquido { get; set; }
        public decimal Frete { get; set; }
        public decimal OutrasDespesas { get; set; }
        public decimal PisImportacao { get; set; }
        public decimal CofinsImportacao { get; set; }
        public decimal Capatazia { get; set; }
        public decimal ContrFti { get; set; }
        public decimal Iof { get; set; }
        public decimal IiSuspenso { get; set; }
        public decimal IpiSuspenso { get; set; }
        public decimal CustoReposicao { get; set; }

    }
}
