using CalculoPrecoVenda.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CalculoPrecoVenda.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //CalculoPreçoVendaContext ctx = new CalculoPreçoVendaContext();

        List<UnidadeFederada> listaUf = new List<UnidadeFederada>();

        private StringBuilder operacao = new StringBuilder();

        // A ser implantando
        public StringBuilder MyOperacao
        {
            get
            {
                return operacao.Append("");

            }
            set
            {
                operacao = value;
                OnPropertyChanged("MyOperacao");
            }
        }

        private Ncm ncm;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public MainWindow()
        {
           
            InitializeComponent();
            
        }

        private void btnImpostosFederais_Click(object sender, RoutedEventArgs e)
        {
            frmImpostosFederais frm = new frmImpostosFederais(txtValorSugerido1.Text,
                                                              txtValorSugerido2.Text,
                                                              txtValorSugerido3.Text,
                                                              txtValorSugerido4.Text,
                                                              txtValorSugerido5.Text);
            frm.ShowDialog();
            frm.Close();
        }

        //A ser implantado
        //private void btnIcms_Click_1(object sender, RoutedEventArgs e)
        //{
        //    frmCalculoICMS frm = new frmCalculoICMS(txtValorSugerido1.Text,
        //                                            txtValorSugerido2.Text,
        //                                            txtValorSugerido3.Text,
        //                                            txtValorSugerido4.Text,
        //                                            txtValorSugerido5.Text);

        //    frm.ShowDialog();
        //    frm.Close();
        //}

        //private void btnDespOp_Click_2(object sender, RoutedEventArgs e)
        //{
        //    frmDespesasOperacionais frm = new frmDespesasOperacionais();
        //    frm.ShowDialog();
        //    frm.Close();
        //}

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9\,]+[0-9]*$"); //Não aceita letras, mas aceita a vírgula mais de uma vez e dá erro
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

        private void btnConfiguracoes_Click(object sender, RoutedEventArgs e)
        {
            frmConfigGerais frm = new frmConfigGerais();
            frm.ShowDialog();
            frm.Close();
        }

        private void btnSobre_Click(object sender, RoutedEventArgs e)
        {
            frmSobre frm = new frmSobre();
            frm.ShowDialog();
            frm.Close();
        }
        private void btnPesquisarNcm_Click(object sender, RoutedEventArgs e)
        {
            ncm = new Ncm();

            frmLocalizarNcm frm = new frmLocalizarNcm();
            frm.ShowDialog();

            ncm = frm.selectedNcm;
            grpProduto.DataContext = ncm;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrecoReposicao precoReposicao = new PrecoReposicao();

            try
            {
                using (CalculoPreçoVendaContext ctx = new CalculoPreçoVendaContext())
                {

                   ctx.Database.Connection.Open();

                    var query = from n in ctx.UFs
                                orderby n.NomeUf
                                select n;

                    foreach (var item in query)
                    {
                        listaUf.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            cbolistaUf.DataContext = listaUf;
            cbolistaUfForn.DataContext = listaUf;
            grdPrecoReposicao.DataContext = precoReposicao;

            radForLocal.IsChecked = true;
            radProdNacional.IsChecked = true;
            radPessoaJurídica.IsChecked = true;
            radClienteLocal.IsChecked = true;
            radPessoaFisica.IsChecked = true;

            chkPpb.IsEnabled = true;

        }
        private void cbolistaUfForn_DropDownClosed(object sender, System.EventArgs e)
        {
            string value = Convert.ToString(cbolistaUfForn.SelectedValue);

            if (value == "EX")
            {
                radForEstrangeiro.IsChecked = true;
                chkPpb.IsChecked = false;
                chkPpb.IsEnabled = false;

                chkImportadoZfm.IsEnabled = true;
                chkCorredor.IsEnabled = true;

                radProdNacional.IsEnabled = false;

            }
            else if (value == "AM")
            {
                radForLocal_Checked(radForLocal, null);
                radForLocal.IsChecked = true;
            }
            else
            {
                chkPpb.IsEnabled = false;
                chkPpb.IsChecked = false;

                chkImportadoZfm.IsEnabled = false;
                chkImportadoZfm.IsChecked = false;

                chkCorredor.IsEnabled = false;
                chkCorredor.IsChecked = false;

                radForEstrangeiro.IsChecked = false;
                radForNacional.IsChecked = true;
                cbolistaUfForn.SelectedValue = value;
            }
        }
        private void radForEstrangeiro_Checked(object sender, RoutedEventArgs e)
        {
            cbolistaUfForn.SelectedValue = "EX";

            radProdNacional.IsEnabled = false;
            radProdEstrangeiro.IsChecked = true;

            chkPpb.IsChecked = false;
            chkPpb.IsEnabled = false;

            chkImportadoZfm.IsEnabled = true;
            chkCorredor.IsEnabled = true;

            chkMicroempresa.IsChecked = false;
            chkMicroempresa.IsEnabled = false;

        }

        private void radForNacional_Checked(object sender, RoutedEventArgs e)
        {
            cbolistaUfForn.SelectedValue = "";

            radProdNacional.IsEnabled = true;
            chkMicroempresa.IsEnabled = true;

            chkCorredor.IsChecked = false;
            chkCorredor.IsEnabled = false;

            chkImportadoZfm.IsChecked = false;
            chkImportadoZfm.IsEnabled = false;

            chkPpb.IsEnabled = false;
            chkPpb.IsChecked = false;

        }
        private void radForLocal_Checked(object sender, RoutedEventArgs e)
        {
            cbolistaUfForn.SelectedValue = "AM";

            radProdNacional.IsEnabled = true;

            chkMicroempresa.IsEnabled = true;

            chkCorredor.IsEnabled = true;
            chkImportadoZfm.IsEnabled = true;
            chkPpb.IsEnabled = true;

            AlertaZfm();

        }
        private void chkMicroempresa_Checked(object sender, RoutedEventArgs e)
        {
            chkPpb.IsEnabled = false;
            chkPpb.IsChecked = false;

            chkSubstTribut.IsEnabled = false;
            chkSubstTribut.IsChecked = false;
        }
        private void chkMicroempresa_Unchecked(object sender, RoutedEventArgs e)
        {
            string value = Convert.ToString(cbolistaUfForn.SelectedValue);

            if (value == "AM")
            {
                chkPpb.IsEnabled = true;
            }

            chkSubstTribut.IsEnabled = true;

        }
        private void radProdEstrangeiro_Checked(object sender, RoutedEventArgs e)
        {
            chkImportadoZfm.IsEnabled = true;
            chkCorredor.IsEnabled = true;
            chkPpb.IsEnabled = false;
            chkPpb.IsChecked = false;

            string value = Convert.ToString(cbolistaUfForn.SelectedValue);

            if (value == "AM")
            {
                chkCorredor.IsEnabled = true;
                chkImportadoZfm.IsEnabled = true;
            }
            else if (value != "EX")
            {
                chkCorredor.IsEnabled = false;
                chkImportadoZfm.IsEnabled = false;
            }
        }
        private void radProdNacional_Checked(object sender, RoutedEventArgs e)
        {
            chkCorredor.IsEnabled = false;
            chkCorredor.IsChecked = false;

            chkImportadoZfm.IsEnabled = false;
            chkImportadoZfm.IsChecked = false;

            chkMotoresAcima90Hp.IsChecked = false;

            string value = Convert.ToString(cbolistaUfForn.SelectedValue);

            if (value == "AM")
            {
                chkPpb.IsEnabled = true;
            }
            else
            {
                chkPpb.IsEnabled = false;
                chkPpb.IsChecked = false;
            }
        }
        private void chkMotoresAte90Hp_Checked(object sender, RoutedEventArgs e)
        {
            chkMotoresAcima90Hp.IsChecked = false;
            chkPecas.IsChecked = false;
            chkEmbarcacoes.IsChecked = false;

            string value = Convert.ToString(cbolistaUfForn.SelectedValue);

            if (value == "AM" && (bool)radProdNacional.IsChecked)
            {
                chkPpb.IsChecked = true;
            }

            AlertaZfm();
        }
        private void chkMotoresAcima90Hp_Checked(object sender, RoutedEventArgs e)
        {
            chkMotoresAte90Hp.IsChecked = false;
            chkPecas.IsChecked = false;
            chkEmbarcacoes.IsChecked = false;
            radProdEstrangeiro.IsChecked = true;


            string value = Convert.ToString(cbolistaUfForn.SelectedValue);

            if (value == "AM")
            {
                chkPpb.IsEnabled = false;
                chkPpb.IsEnabled = false;
            }

            AlertaZfm();
        }
        private void chkPecas_Checked(object sender, RoutedEventArgs e)
        {
            chkMotoresAcima90Hp.IsChecked = false;
            chkMotoresAte90Hp.IsChecked = false;
            chkEmbarcacoes.IsChecked = false;

            if ((bool)chkSubstTribut.IsChecked && (bool)chkPecas.IsChecked)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("As peças de motor de popa não seguem o regima de Substituição Tributária", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                chkSubstTribut.IsChecked = false;

            }
        }
        private void chkEmbarcacoes_Checked(object sender, RoutedEventArgs e)
        {
            chkMotoresAcima90Hp.IsChecked = false;
            chkMotoresAte90Hp.IsChecked = false;
            chkPecas.IsChecked = false;
        }
        private void chkCorredor_Checked(object sender, RoutedEventArgs e)
        {
            chkImportadoZfm.IsChecked = false;
            radProdEstrangeiro.IsChecked = true;
        }

        private void chkImportadoZfm_Checked(object sender, RoutedEventArgs e)
        {
            chkCorredor.IsChecked = false;
            radProdEstrangeiro.IsChecked = true;

            AlertaZfm();
        }

        private void radClienteEstrangeiro_Checked(object sender, RoutedEventArgs e)
        {
            cbolistaUf.SelectedValue = "EX";

            chkClienteZfm.IsEnabled = false;
            chkClienteZfm.IsChecked = false;

            radPessoaJurídica.IsEnabled = false;
            radPessoaJurídica.IsChecked = false;

            radPessoaFisica.IsEnabled = false;
            radPessoaFisica.IsChecked = false;

        }
        private void radClienteNacional_Checked(object sender, RoutedEventArgs e)
        {
            cbolistaUf.SelectedValue = "";
            chkClienteZfm.IsEnabled = false;
            chkClienteZfm.IsChecked = false;

            radPessoaJurídica.IsEnabled = true;
            radPessoaFisica.IsEnabled = true;
            radPessoaFisica.IsChecked = true;

            AlertaZfm();
        }
        private void radClienteLocal_Checked(object sender, RoutedEventArgs e)
        {
            cbolistaUf.SelectedValue = "AM";

            chkClienteZfm.IsEnabled = true;
            radPessoaJurídica.IsEnabled = true;
            radPessoaFisica.IsEnabled = true;
            radPessoaFisica.IsChecked = true;
        }

        private void radPessoaJurídica_Checked(object sender, RoutedEventArgs e)
        {
            chkItensFcp.IsEnabled = false;
            chkItensFcp.IsChecked = false;
        }

        private void radPessoaFisica_Checked(object sender, RoutedEventArgs e)
        {
            chkItensFcp.IsEnabled = true;
        }

        private void cbolistaUf_DropDownClosed(object sender, EventArgs e)
        {
            string value = Convert.ToString(cbolistaUf.SelectedValue);

            if (value == "EX")
            {
                radClienteEstrangeiro.IsChecked = true;

            }
            else if (value == "AM")
            {
                radClienteLocal.IsChecked = true;
            }
            else
            {
                radClienteNacional.IsChecked = true;
            }
        }

        private void chkSubstTribut_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)chkPecas.IsChecked)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("As peças de motor de popa não seguem o regima de Substituição Tributária", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                chkPecas.IsChecked = false;

            }
        }
        private void chkPpb_Checked(object sender, RoutedEventArgs e)
        {
            radForLocal.IsChecked = true;
            radProdNacional.IsChecked = true;
        }

        private void AlertaZfm()
        {

            if ((bool)chkImportadoZfm.IsChecked)
            {
                if (((bool)radProdEstrangeiro.IsChecked) && (bool)(radClienteNacional.IsChecked))
                {
                    if ((bool)chkMotoresAcima90Hp.IsChecked || (bool)chkMotoresAte90Hp.IsChecked)
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Foi selecionada a operação:\n" +
                        "PRODUTO ESTRANGEIRO ADQUIRIDO PARA A ZFM VENDIDO PARA OUTRA UF (MOTOR DE POPA).\nInforme a NCM para cálculo do II e do IPI Suspensos.\n" +
                        "---------------------------------------\n" + "NCM 84072190 - QQ.OUTRO MOTOR P/EMBARC.FIX.EXT. AO CASCO", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        Xceed.Wpf.Toolkit.MessageBox.Show("Foi selecionada a operação:\n" +
                            "PRODUTO ESTRANGEIRO ADQUIRIDO PARA A ZFM VENDIDO PARA OUTRA UF.\nInforme a NCM para cálculo do II e do IPI Suspensos.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                } 
            }

            if ((bool)radForLocal.IsChecked && (bool)chkMotoresAcima90Hp.IsChecked)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Foi selecionada a operação:\n" +
                            "REVENDA DE MOTOR ACIMA DE 90HP COMPRADO NO AM.\nSerá incluido no Custo o frete no valor de R$ " + Settings.Default.FreteMotAcima90HP.ToString("n2") + " , ref. aos acessórios saindo de SP.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void txtNcm_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNcm.Text == "")
            {
                grpProduto.DataContext = null;
            }
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement c = grpCusto;
            FrameworkElement v = grpPrecoVenda;

            if (c == null || v == null)
            {
                return;
            }

            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                //Pega a capacidade da Impressora
                PrintCapabilities capabilities = print.PrintQueue.GetPrintCapabilities(print.PrintTicket);

                //Transforma as medidas do control proporcional a do página da impressora
                double escalaCusto = Math.Min(
                    capabilities.PageImageableArea.ExtentWidth / c.ActualWidth,
                    capabilities.PageImageableArea.ExtentHeight / c.ActualHeight);

                double escalaVenda = Math.Min(
                   capabilities.PageImageableArea.ExtentWidth / v.ActualWidth,
                   capabilities.PageImageableArea.ExtentHeight / v.ActualHeight);

                //Armazena  o layout original do control
                Transform tamanhoGrupoCustoOriginal = c.LayoutTransform;
                Transform tamanhoGrupoVendaOriginal = v.LayoutTransform;

                //Alterar o control para a nova escala
                c.LayoutTransform = new ScaleTransform(escalaCusto, escalaCusto);
                v.LayoutTransform = new ScaleTransform(escalaVenda, escalaVenda);

                //Armazena o tamnho origianl do control
                Size oldSizeCusto = new Size(c.ActualWidth, c.ActualHeight);
                Size oldSizeVenda = new Size(v.ActualWidth, v.ActualHeight);

                //Tamaho do papel configurado na Impressora
                Size size = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);

                //Atualiza o tamnho para caber na pagina
                c.Measure(size);
                c.Arrange(new Rect(new Point(
                    capabilities.PageImageableArea.OriginWidth,
                    capabilities.PageImageableArea.OriginHeight), size));

                v.Measure(size);
                v.Arrange(new Rect(new Point(
                    capabilities.PageImageableArea.OriginWidth,
                    capabilities.PageImageableArea.OriginHeight), size));

                //print.PrintTicket.PageOrientation = PageOrientation.Landscape;

                //Imprime
                print.PrintVisual(c, "Mémoria de Cálculo Custo");
                print.PrintVisual(v, "Mémoria de Cálculo Venda");

                //Volta o tamanho original do control
                c.LayoutTransform = tamanhoGrupoCustoOriginal;
                c.Measure(oldSizeCusto);
                c.Arrange(new Rect(new Point(0, 0), oldSizeCusto));

                v.LayoutTransform = tamanhoGrupoVendaOriginal;
                v.Measure(oldSizeVenda);
                v.Arrange(new Rect(new Point(0, 0), oldSizeVenda));

            }
        }
    }
}
