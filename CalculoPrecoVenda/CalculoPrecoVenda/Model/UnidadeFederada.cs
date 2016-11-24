using System.ComponentModel;

namespace CalculoPrecoVenda.Model
{
    public class UnidadeFederada 
    {
        private int ufId;
        private string nomeUf;
        private string siglaUf;
        private double aliquotaInterna;
        private double aliquotaFcp;
        private double aliquotaInterestadual;
        private string itensFcp;
        public int UfId
        {
            get { return ufId; }
            set { ufId = value; }
        }
        public string NomeUf
        {
            get { return nomeUf; }
            set { nomeUf = value; }
        }
        public string SiglaUf
        {
            get { return siglaUf; }
            set { siglaUf = value; }
        }
        public double AliquotaInterna
        {
            get { return aliquotaInterna; }
            set { aliquotaInterna = value; }
        }
        public double AliquotaFcp
        {
            get { return aliquotaFcp; }
            set { aliquotaFcp = value; }
        }

        public double AliquotaInterestadual
        {
            get { return aliquotaInterestadual; }
            set { aliquotaInterestadual = value; }
        }
        public string ItensFcp
        {
            get { return itensFcp; }
            set { itensFcp = value; }
        }
    }
}

