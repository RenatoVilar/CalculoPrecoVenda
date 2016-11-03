using CalculoPrecoVenda.Model;
using MVVMFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoPrecoVenda.ViewModel
{
    class NcmViewModel : Bindable
    {

        CalculoPreçoVendaContext ctx = new CalculoPreçoVendaContext();
        public ObservableCollection<Ncm> Ncms { get; set; }

        public NcmViewModel()
            :base()
        {

        }

        private Ncm ncm;

        public Ncm Ncm
        {
            get { return ncm; }
            set { SetValue(ref ncm, value); }
        }

        private int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                SetValue(ref selectedIndex, value);

                if (selectedIndex >= 0)
                {
                    Ncm = Ncms[selectedIndex];
                }
            }
        }

        

        


    }
}
