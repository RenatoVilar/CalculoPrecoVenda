using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using CalculoPrecoVenda.View;
using CalculoPrecoVenda.ViewModel;

namespace CalculoPrecoVenda.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void btnImpostosFederais_Click(object sender, RoutedEventArgs e)
        {
            frmImpostosFederais frm = new frmImpostosFederais();
            frm.ShowDialog();
            frm.Close();
        }

        private void btnIcms_Click_1(object sender, RoutedEventArgs e)
        {
            frmCalculoICMS frm = new frmCalculoICMS();
            frm.ShowDialog();
            frm.Close();
        }

        private void btnDespOp_Click_2(object sender, RoutedEventArgs e)
        {
            frmDespesasOperacionais frm = new frmDespesasOperacionais();
            frm.ShowDialog();
            frm.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnCadastroUf_Click(object sender, RoutedEventArgs e)
        {
            frmUnidadeFederada frm = new frmUnidadeFederada();
            frm.ShowDialog();
            frm.Close();
        }

        private void btnCadastroNcm_Click(object sender, RoutedEventArgs e)
        {
            frmNcm frm = new frmNcm();
            frm.ShowDialog();
            frm.Close();
        }

        private void btnSobre_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
