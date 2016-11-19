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
using CalculoPrecoVenda.Model;

namespace CalculoPrecoVenda.View
{
    /// <summary>
    /// Interaction logic for frmLocalizarUnidadeFederada.xaml
    /// </summary>
    public partial class frmLocalizarUnidadeFederada : Window
    {
        CalculoPreçoVendaContext ctx = new CalculoPreçoVendaContext();

        public UnidadeFederada selectedUf;
        public frmLocalizarUnidadeFederada()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            List<UnidadeFederada> ufs = new List<UnidadeFederada>();

                var query = from n in ctx.UFs
                            where n.NomeUf.Contains(txtPesquisar.Text)
                            select n;

                ufs = query.ToList();

            if (ufs.Count == 0)
            {
                MessageBox.Show("Nenhum item encontrado!");
            }

            dtgUf.ItemsSource = ufs;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            selectedUf = new UnidadeFederada();

            selectedUf = (UnidadeFederada)dtgUf.SelectedValue;
            Close();
        }
    }
}
