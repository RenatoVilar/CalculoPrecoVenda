using CalculoPrecoVenda.Model;
using CalculoPrecoVenda.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CalculoPrecoVenda.View
{
    /// <summary>
    /// Interaction logic for frmNcm.xaml
    /// </summary>
    public partial class frmNcm : Window
    {
        CalculoPreçoVendaContext ctx = new CalculoPreçoVendaContext();

        //public Ncm Ncm { get; set; }

        public frmNcm()
        {
            InitializeComponent();
            this.DataContext = new NcmViewModel();
        }

        private void btnLocalizar_Click(object sender, RoutedEventArgs e)
        {
            frmLocalizarNcm frm = new frmLocalizarNcm();
            frm.ShowDialog();
            if (frm.codigo != 0)
            {
                Ncm ncm = new Ncm();
                
                this.DataContext = from n in ctx.Ncms
                                   where n.NcmId == frm.codigo
                                   select n;
                
            }

            frm.Close();
        }
    }
}
