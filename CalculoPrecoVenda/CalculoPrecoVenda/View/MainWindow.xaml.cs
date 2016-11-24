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

            cbolistaUfForn.SelectedIndex = 1;
            
            radForZfm.IsChecked = true;
            radProdEstrangeiro.IsChecked = true;
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
            
        }
    }
}
