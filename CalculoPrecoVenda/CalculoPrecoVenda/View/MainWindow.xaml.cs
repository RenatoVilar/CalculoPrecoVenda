using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using CalculoPrecoVenda.View;
using CalculoPrecoVenda.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System;

namespace CalculoPrecoVenda.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        CalculoPreçoVendaContext ctx = new CalculoPreçoVendaContext();
        List<UnidadeFederada> listaUf = new List<UnidadeFederada>();

        private Ncm ncm;

       
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
            Regex regex = new Regex("[^0-9\n]");
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

        private void btnPesquisarNcm_Click(object sender, RoutedEventArgs e)
        {
            ncm = new Ncm();

            frmLocalizarNcm frm = new frmLocalizarNcm();
            frm.ShowDialog();

            ncm = frm.selectedNcm;

            txtNcm.DataContext = ncm;
            txbNomeNcm.DataContext = ncm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrecoReposicao precoReposicao = new PrecoReposicao();

            var query = from n in ctx.UFs
                        select n;

            foreach (var item in query)
            {
                listaUf.Add(item);
            }

            cbolistaUf.DataContext = listaUf;
            cbolistaUfForn.DataContext = listaUf;
            grdPrecoReposicao.DataContext = precoReposicao;

            cbolistaUfForn.SelectedIndex = 0;

            radForNacional.IsChecked = true;
            radProdNacional.IsChecked = true;
            radPessoaJurídica.IsChecked = true;
        }

        private void txtValorNF_LostFocus(object sender, RoutedEventArgs e)
        {
            

           
        }

        private void txtValorNF_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
                        
        }

        private void cbolistaUfForn_DropDownClosed(object sender, System.EventArgs e)
        {

            string value = Convert.ToString(cbolistaUfForn.SelectedValue);

            if (value == "EX")
            {
                radForEstrangeiro.IsChecked = true;
                radForNacional.IsChecked = false;
                chkPpb.IsChecked = false;

                chkImportadoZfm.IsEnabled = true;
                chkCorredor.IsEnabled = true;
                chkPpb.IsEnabled = false;

                radProdNacional.IsEnabled = false;

            }
            else if (value == "AM")
            {
                chkPpb.IsEnabled = true;
                chkImportadoZfm.IsEnabled = true;
                chkCorredor.IsEnabled = true;
                if ((bool)radProdEstrangeiro.IsChecked)
                {
                    chkPpb.IsChecked = false;
                    chkPpb.IsEnabled = false;
                }
            }
            else
            {
                chkPpb.IsEnabled = false;
                chkImportadoZfm.IsEnabled = false;
                chkCorredor.IsEnabled = false;

                chkPpb.IsChecked= false;
                chkImportadoZfm.IsChecked = false;
                chkCorredor.IsChecked = false;

            }
                

        }
        private void radForEstrangeiro_Checked(object sender, RoutedEventArgs e)
        {
            cbolistaUfForn.SelectedValue = "EX";

            radProdNacional.IsEnabled = false;
            radProdEstrangeiro.IsChecked = true;

            chkPpb.IsChecked= false;
            chkPpb.IsEnabled = false;

            chkPecas.IsEnabled = true;

            chkImportadoZfm.IsEnabled = true;
            chkCorredor.IsEnabled = true;
        }

        private void radForNacional_Checked(object sender, RoutedEventArgs e)
        {
            cbolistaUfForn.SelectedValue = "AM";

            radProdNacional.IsEnabled = true;

            string value = Convert.ToString(cbolistaUfForn.SelectedValue);
            
            if (value == "AM")
            {
                chkCorredor.IsEnabled = true;
                chkImportadoZfm.IsEnabled = true;

            }
            else
            {
                chkPpb.IsEnabled = false;
                chkCorredor.IsEnabled = false;
                chkImportadoZfm.IsEnabled = false;
            }
        }

        private void chkCorredor_Checked(object sender, RoutedEventArgs e)
        {
            chkImportadoZfm.IsChecked = false;
        }

        private void chkImportadoZfm_Checked(object sender, RoutedEventArgs e)
        {
            chkCorredor.IsChecked = false;
        }

        private void chkMotores_Checked(object sender, RoutedEventArgs e)
        {
            chkPecas.IsChecked = false;
        }

        private void chkPecas_Checked(object sender, RoutedEventArgs e)
        {
            chkMotores.IsChecked = false;
        }

        private void radEstrangeiro_Checked(object sender, RoutedEventArgs e)
        {
            cbolistaUf.SelectedValue = "AM";
        }

        private void radProdEstrangeiro_Checked(object sender, RoutedEventArgs e)
        {
            chkImportadoZfm.IsEnabled = true;
            chkCorredor.IsEnabled = true;
            chkPpb.IsEnabled = false;

            string value = Convert.ToString(cbolistaUfForn.SelectedValue);

            if (value == "AM")
            {
                chkCorredor.IsEnabled = true;
                chkImportadoZfm.IsEnabled = true;
            }
            else
            {
                chkCorredor.IsEnabled = false;
                chkImportadoZfm.IsEnabled = false;
            }
        }

        private void radProdNacional_Checked(object sender, RoutedEventArgs e)
        {
            chkCorredor.IsEnabled = false;
            chkImportadoZfm.IsEnabled = false;

            string value = Convert.ToString(cbolistaUfForn.SelectedValue);

            if (value == "AM")
            {
                chkCorredor.IsEnabled = true;
                chkImportadoZfm.IsEnabled = true;
                chkPpb.IsEnabled = true;

            }
            else
            {
                chkPpb.IsEnabled = false;
                chkCorredor.IsEnabled = false;
                chkImportadoZfm.IsEnabled = false;
            }
        }
    }
}
