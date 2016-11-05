using MVVMFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoPrecoVenda.Model
{
    public class Ncm : Bindable
    {
        private int ncmId;
        public int NcmId
        {
            get { return ncmId; }
            set { SetValue(ref ncmId, value); }
        }

        private string codNcm;
        public string CodNcm
        {
            get { return codNcm; }
            set
            {
                SetValue(ref codNcm, value);
                if (string.IsNullOrEmpty(codNcm))
                {
                    AddError("O código da NCM deve ser preenchido!");
                }
            }

        }

        private string nomeNcm;
        public string NomeNcm
        {
            get { return nomeNcm; }
            set
            {
                SetValue(ref nomeNcm, value);
                if (string.IsNullOrEmpty(nomeNcm))
                {
                    AddError("A descrição da NCM deve ser preenchida!");
                }
            }
        }

        private double? impImportacao;
        public double? ImpImportacao
        {
            get { return ImpImportacao; }
            set { SetValue(ref impImportacao, value); }
        }

        private double? ipi;
        public double? Ipi
        {
            get { return ipi; }
            set { SetValue(ref ipi, value); }
        }

    }
}
