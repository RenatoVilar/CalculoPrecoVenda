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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace CalculoPrecoVenda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
