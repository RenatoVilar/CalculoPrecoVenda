using CalculoPrecoVenda.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace CalculoPrecoVenda.View
{
    /// <summary>
    /// Interaction logic for frmUnidadeFederada.xaml
    /// </summary>
    public partial class frmUnidadeFederada : Window
    {
        CalculoPreçoVendaContext ctx = new CalculoPreçoVendaContext();

        public UnidadeFederada uf;

        private string operacao;
        public frmUnidadeFederada()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AlterarBotoes(1);
            uf = new UnidadeFederada();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            uf = new UnidadeFederada();

            grdCadastroUF.DataContext = uf;

            operacao = "Novo";

            AlterarBotoes(2);
        }

        private void btnLocalizar_Click(object sender, RoutedEventArgs e)
        {
            uf = new UnidadeFederada();

            frmLocalizarUnidadeFederada frm = new frmLocalizarUnidadeFederada();

            frm.ShowDialog();		

            AlterarBotoes(3);

            uf = frm.selectedUf;
            gpbCadastroUF.IsEnabled = false;

            grdCadastroUF.DataContext = uf;
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            operacao = "Alterar";
            AlterarBotoes(2);
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            int ufId = Convert.ToInt32(txtUfId.Text);

            MessageBoxResult result = MessageBox.Show("Deseja Excluir o registro", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                uf = ctx.UFs.Find(ufId);
                ctx.UFs.Remove(uf);
                ctx.SaveChanges();
            }

            LimparTela();
            AlterarBotoes(1);
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var ufs = ctx.UFs.ToList<UnidadeFederada>();

            if (string.IsNullOrEmpty(txtSiglaUf.Text))
            {
                MessageBox.Show("Informe a Sigla da UF!");
                return;
            }

            if (string.IsNullOrEmpty(txtNomeUf.Text))
            {
                MessageBox.Show("Informe o nome da UF!");
                return;
            }

            if (string.IsNullOrEmpty(txtAlIcmsInterna.Text) || txtAlIcmsInterna.Text == "0,00")
            {
                MessageBox.Show("Informe a alíquota interna!");
                return;
            }

            if (string.IsNullOrEmpty(txtAlIcmsInterestadual.Text) || txtAlIcmsInterna.Text == "0,00")
            {
                MessageBox.Show("Informe a alíquota interna!");
                return;
            }

            if (operacao == "Novo")
            {
                ctx.UFs.Add(new UnidadeFederada()
                {
                    NomeUf = txtNomeUf.Text.ToUpper(),
                    SiglaUf = txtSiglaUf.Text.ToUpper(),
                    AliquotaInterna = Convert.ToDouble(txtAlIcmsInterna.Text),
                    AliquotaInterestadual = Convert.ToDouble(txtAlIcmsInterestadual.Text),
                    AliquotaFcp = Convert.ToDouble(txtAlFcp.Text),
                    AliquotaEmbarcacoes = Convert.ToDouble(txtAlEmbarcacoes.Text),
                    ItensFcp = txtItensFcp.Text

                });

                ctx.SaveChanges();

                MessageBox.Show(String.Format($"Cadastro efetuado com sucesso!\n UF {txtSiglaUf.Text.ToUpper()} - {txtNomeUf.Text.ToUpper()}"));
            }
            else
            {
                UnidadeFederada ufToUpdate = ufs.Where(n => n.UfId == Convert.ToInt32(txtUfId.Text)).FirstOrDefault<UnidadeFederada>();
                ufToUpdate.NomeUf = txtNomeUf.Text.ToUpper();
                ufToUpdate.SiglaUf = txtSiglaUf.Text.ToUpper();
                ufToUpdate.AliquotaInterna = Convert.ToDouble(txtAlIcmsInterna.Text);
                ufToUpdate.AliquotaInterestadual = Convert.ToDouble(txtAlIcmsInterestadual.Text);
                ufToUpdate.AliquotaFcp = Convert.ToDouble(txtAlFcp.Text);
                ufToUpdate.AliquotaEmbarcacoes = Convert.ToDouble(txtAlEmbarcacoes.Text);
                ufToUpdate.ItensFcp = txtItensFcp.Text;

                ctx.SaveChanges();

                MessageBox.Show(String.Format($"Cadastro alterado com sucesso!\n UF {txtSiglaUf.Text.ToUpper()} - {txtNomeUf.Text.ToUpper()}"));
            }

            LimparTela();
            AlterarBotoes(1);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimparTela();
            AlterarBotoes(1);
        }

        public void AlterarBotoes(int op)
        {
            btnNovo.IsEnabled = false;
            btnLocalizar.IsEnabled = false;
            btnAlterar.IsEnabled = false;
            btnExcluir.IsEnabled = false;
            btnSalvar.IsEnabled = false;
            gpbCadastroUF.IsEnabled = false;

            if (op == 1)
            {
                btnNovo.IsEnabled = true;
                btnLocalizar.IsEnabled = true;
                gpbCadastroUF.IsEnabled = false;
            }
            if (op == 2)
            {
                btnSalvar.IsEnabled = true;
                btnCancelar.IsEnabled = true;
                gpbCadastroUF.IsEnabled = true;
            }
            if (op == 3)
            {
                btnAlterar.IsEnabled = true;
                btnExcluir.IsEnabled = true;
                btnCancelar.IsEnabled = true;
                gpbCadastroUF.IsEnabled = true;
            }
        }

        private void LetterValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void LimparTela()
        {
            txtUfId.Clear();
            txtNomeUf.Clear();
            txtSiglaUf.Clear();
            txtAlIcmsInterna.Clear();
            txtAlIcmsInterestadual.Clear();
            txtAlFcp.Clear();
            txtAlEmbarcacoes.Clear();
            txtItensFcp.Clear();
        }


    }
}
