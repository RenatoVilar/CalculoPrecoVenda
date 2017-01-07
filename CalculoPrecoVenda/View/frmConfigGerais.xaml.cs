using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace CalculoPrecoVenda
{
    /// <summary>
    /// Interaction logic for frmConfigGerais.xaml
    /// </summary>
    public partial class frmConfigGerais : Window
    {
        public frmConfigGerais()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9\,]+[0-9]*$"); //Não aceita letras, mas aceita a vírgula mais de uma vez e dá erro
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.Irpj = Convert.ToDouble(txtIrpj.Text);
            Settings.Default.Csll = Convert.ToDouble(txtCsll.Text);
            Settings.Default.Pis = Convert.ToDouble(txtPis.Text);
            Settings.Default.Cofins = Convert.ToDouble(txtCofins.Text);
            Settings.Default.Lucro1 = Convert.ToDouble(txtLucro01.Text);
            Settings.Default.Lucro2 = Convert.ToDouble(txtLucro02.Text);
            Settings.Default.Lucro3 = Convert.ToDouble(txtLucro03.Text);
            Settings.Default.Lucro4 = Convert.ToDouble(txtLucro04.Text);
            Settings.Default.Lucro5 = Convert.ToDouble(txtLucro05.Text);
            Settings.Default.Capatazia = Convert.ToDouble(txtCapatazia.Text);
            Settings.Default.Fti = Convert.ToDouble(txtFti.Text);
            Settings.Default.FreteMotAcima90HP = Convert.ToDouble(txtFrete.Text);
            Settings.Default.AliquotaIcmsMicro = Convert.ToDouble(txtAlMicroempresa.Text);
            Settings.Default.AliquotaIcmsInterImportados = Convert.ToDouble(txtAlIcmsProdImportados.Text);

            Settings.Default.Save();
            MessageBox.Show("As Configurações foram gravadas com sucesso!", "Mensagem", MessageBoxButton.OK, MessageBoxImage.Information);
           
        }
        private void textChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            if (btnSalvar != null)
            {
                btnSalvar.IsEnabled = true;
            }

        }
    }
}
