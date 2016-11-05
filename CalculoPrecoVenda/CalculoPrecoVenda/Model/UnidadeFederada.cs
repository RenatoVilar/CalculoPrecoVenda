using MVVMFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoPrecoVenda.Model
{
    public class UnidadeFederada : Bindable
    {
        private int ufId;
        public int UfId
        {
            get { return ufId; }
            set { SetValue(ref ufId, value); }
        }

        private string nomeUf;
        public string NomeUf
        {
            get { return nomeUf; }
            set
            {
                SetValue(ref nomeUf, value);
                if (string.IsNullOrEmpty(nomeUf))
                {
                    AddError("O nome da UF deve ser preenchido!");
                }
            }
        }

        private string siglaUf;
        public string SiglaUf
        {
            get { return siglaUf; }
            set
            {
                SetValue(ref siglaUf, value);
                if (string.IsNullOrEmpty(siglaUf))
                {
                    AddError("A sigla da UF deve ser preenchida!");
                }
            }
        }

        private double aliquotaInterna;
        public double AliquotaInterna
        {
            get { return aliquotaInterna; }
            set { SetValue(ref aliquotaInterna, value); }
        }

        private double aliquotaFcp;
        public double AliquotaFcp
        {
            get { return aliquotaFcp; }
            set { SetValue(ref aliquotaFcp, value); }
        }

        private string itensFcp;
        public string ItensFcp
        {
            get { return itensFcp; }
            set { SetValue(ref itensFcp, value); }
        }
    }
}

