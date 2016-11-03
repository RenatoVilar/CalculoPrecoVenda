using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFramework;
using System.Data.Entity;
using CalculoPrecoVenda.Model;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace CalculoPrecoVenda.ViewModel
{
    class LocalizarNCMViewModel : Bindable
    {
        CalculoPreçoVendaContext ctx = new CalculoPreçoVendaContext();
        public ObservableCollection<Ncm> Ncms { get; set; }
       
        public LocalizarNCMViewModel()
            : base()
        {
            PesquisarCommand = new Command(Pesquisar);
        }

        public Command PesquisarCommand { get; set; }

        void Pesquisar()
        {
            ObservableCollection<Ncm> _ncms = new ObservableCollection<Ncm>();
            var ncms = from n in ctx.Ncms select n;

            foreach (Ncm ncm in ncms)
            {
                _ncms.Add(ncm);
            }
            Ncms = _ncms;
            OnPropertyChanged("Ncms");

            MessageBox.Show(Ncms.Count.ToString());


        }
    }
}