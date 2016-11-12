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
    /// Interaction logic for frmLocalizarNcm.xaml
    /// </summary>
    public partial class frmLocalizarNcm : Window
    {
        CalculoPreçoVendaContext ctx;

        public Ncm selectedNcm;
        public frmLocalizarNcm()
        {
            InitializeComponent();
            
        }
            
        public int codigo = 0;

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            ctx = new CalculoPreçoVendaContext();

            int indexCboBox = cboLocalizarNCM.SelectedIndex;

            if (indexCboBox == 0) // 0 = NCM | 1 = Descrição
            {
                var query = from n in ctx.Ncms
                            where n.CodNcm.Contains(txtPesquisa.Text)
                            select n;

                var ncms = query.ToList();

                dtgNcm.ItemsSource = ncms;
            }
            else if (indexCboBox == 1)
            {
                var query = from n in ctx.Ncms
                            where n.NomeNcm.Contains(txtPesquisa.Text)
                            select n;

                var ncms = query.ToList();

                dtgNcm.ItemsSource = ncms;
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            selectedNcm = new Ncm();

            selectedNcm = (Ncm)dtgNcm.SelectedValue;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboLocalizarNCM.Items.Add("NCM");
            cboLocalizarNCM.Items.Add("Descrição");
            cboLocalizarNCM.SelectedIndex = 0;
        }
    }
}
