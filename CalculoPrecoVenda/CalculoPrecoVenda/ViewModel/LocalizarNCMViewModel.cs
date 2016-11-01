using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFramework;
using System.Data.Entity;
using CalculoPrecoVenda.Model;
using System.Windows.Input;


namespace CalculoPrecoVenda.ViewModel
{
    class LocalizarNCMViewModel : Bindable
    {
        CalculoPreçoVendaContext ctx = new CalculoPreçoVendaContext();

        public LocalizarNCMViewModel()
        {
            PesquisarCommand = new Command(Pesquisar);
        }

        private List<Ncm> ncms;
        public List<Ncm> Ncms
        {
            get { return ncms; }
            set { SetValue(ref ncms, value); }
        }

        public Command PesquisarCommand { get; set; }

        void Pesquisar()
        {

            var query = from n in ctx.Ncms
                   select n;

            foreach (var item in query)
            {
                Ncms.Add(item);
            }


        }
    }
}