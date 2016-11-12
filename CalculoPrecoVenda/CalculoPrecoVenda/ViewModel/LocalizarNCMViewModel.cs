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
        //CalculoPreçoVendaContext ctx = new CalculoPreçoVendaContext();
        //public ObservableCollection<Ncm> Ncms { get; set; }

        //public LocalizarNCMViewModel()
        //    : base()
        //{
        //    PesquisarCommand = new Command(Pesquisar);
        //    SelecionarCommand = new Command(Selecionar);

        //}

        //public Command PesquisarCommand { get; set; }

        //public Command SelecionarCommand { get; set; }

        //private string textoPesquisa;
        //public string TextoPesquisa
        //{
        //    get { return textoPesquisa; }
        //    set { SetValue(ref textoPesquisa, value); }
        //}

        //private Ncm ncm;
        //public Ncm Ncm
        //{
        //    get { return ncm; }
        //    set { SetValue(ref ncm, value); }
        //}

        //private int selectedIndex;
        //public int SelectedIndex
        //{
        //    get { return selectedIndex; }
        //    set
        //    {
        //        SetValue(ref selectedIndex, value);

        //        if (selectedIndex >= 0)
        //        {
        //            Ncm = Ncms[selectedIndex];
        //        }
        //    }
        //}

        //private List<Ncm> selectedNcm;
        //public List<Ncm> SelectedNcm
        //{
        //    get { return selectedNcm; }
        //    set { SetValue(ref selectedNcm, value); }
        //}


        //void Pesquisar()
        //{
        //    ObservableCollection<Ncm> _ncms = new ObservableCollection<Ncm>();
        //    var ncms = from n in ctx.Ncms
        //               where n.NomeNcm.Contains(TextoPesquisa)
        //               select n;

        //    foreach (Ncm ncm in ncms)
        //    {
        //        _ncms.Add(ncm);
        //    }

        //    Ncms = _ncms;
        //    OnPropertyChanged("Ncms");
        //}

        //void Selecionar()
        //{
        //    NcmViewModel frm = new NcmViewModel(Ncm);

        //    List<Ncm> _selectedNcm = new List<Ncm>();

        //    var query = from n in ctx.Ncms
        //                where n.NcmId == selectedIndex
        //                select n;

        //    foreach (Ncm ncm in query)
        //    {
        //        _selectedNcm.Add(ncm);
        //    }

        //}

    }
    
}