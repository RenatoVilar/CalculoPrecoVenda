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
        private string codNcm;
        private string nomeNCm;
        private double? impImportacao;
        private double? ipi;

        public int NcmId
        {
            get { return ncmId; }
            set { SetValue(ref ncmId, value); }
        }

        public string CodNcm
        {
            get { return codNcm; }
            set
            {
                SetValue(ref codNcm, value);

                if (string.IsNullOrEmpty(codNcm) || codNcm.Length < 8)
                {
                    AddError("O código da NCM deve conter 8 digitos!");
                }
                else
                {
                    RemoveErrors();
                }
            }
        }
        public string NomeNcm
        {
            get { return nomeNCm; }
            set
            {
                SetValue(ref nomeNCm, value);
                if (string.IsNullOrEmpty(nomeNCm))
                {
                    AddError("A descrição da NCM não pode ficar em branco");
                }
                else
                {
                    RemoveErrors();
                }
            }
        }
        
        public double? ImpImportacao
        {
            get { return impImportacao; }
            set { SetValue(ref impImportacao, value); }
        }
        
        public double? Ipi
        {
            get { return ipi; }
            set { SetValue(ref ipi, value); }
        }
    }
}
