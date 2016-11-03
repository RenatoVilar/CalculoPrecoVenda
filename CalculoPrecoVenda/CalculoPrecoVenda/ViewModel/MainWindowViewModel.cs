using MVVMFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoPrecoVenda.ViewModel
{
    class MainWindowViewModel : Bindable
    {
        public MainWindowViewModel()
            :base()
        {

        }

        private string txtValorNF;

        public string TxtValorNF
        {
            get { return txtValorNF; }
            set
            {
                SetValue(ref txtValorNF, value);
                OnPropertyChanged("ValorLiquido");

            }
        }

        private string txtIcms;

        public string TxtIcms
        {
            get { return txtIcms; }
            set
            {
                SetValue(ref txtIcms, value);
                OnPropertyChanged("ValorLiquido");

            }
        }

            

        public string ValorLiquido
        {
            get { return txtValorNF + TxtIcms; }
            
        }


    }
}
