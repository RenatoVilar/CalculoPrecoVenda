using CalculoPrecoVenda.Model;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace CalculoPrecoVenda.View
{
    /// <summary>
    /// Interaction logic for frmNcm.xaml
    /// </summary>
    public partial class frmNcm : Window
    {
        CalculoPreçoVendaContext ctx = new CalculoPreçoVendaContext();

        public Ncm ncm { get; set; }
        
        private string operacao;

        public frmNcm()
        {
            InitializeComponent();
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AlterarBotoes(1);
            ncm = new Ncm();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            ncm = new Ncm();
           
            gridNcm.DataContext = ncm;

            operacao = "Novo";

            AlterarBotoes(2);
            
        }

        private void btnLocalizar_Click(object sender, RoutedEventArgs e)
        {
            ncm = new Ncm();

            frmLocalizarNcm frm = new frmLocalizarNcm();
          
            frm.ShowDialog();
            AlterarBotoes(3);

            ncm = frm.selectedNcm;
            gpbCadastroNcm.IsEnabled = false;

            gridNcm.DataContext = ncm;
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            operacao = "Alterar";
            AlterarBotoes(2);
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            int ncmId = Convert.ToInt32(txtNcmId.Text);

            MessageBoxResult result = MessageBox.Show("Deseja Excluir o registro", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                ncm = ctx.Ncms.Find(ncmId);
                ctx.Ncms.Remove(ncm);
                ctx.SaveChanges(); 
            }

            txtCodNcm.Clear();
            txtImpImportacao.Clear();
            txtIpi.Clear();
            txtNcmId.Clear();
            txtNomeNcm.Clear();
            txtMva.Clear();
            chkAutopecas.IsChecked = false;
            chkSemSimilar.IsChecked = false;
            AlterarBotoes(1);

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var ncms = ctx.Ncms.ToList<Ncm>();

            if (string.IsNullOrEmpty(txtNomeNcm.Text))
            {
                MessageBox.Show("A descrição da NCM não pode ficar em branco!");
                return;
            }

            if (operacao == "Novo")
            {
                try
                {
                    ctx.Ncms.Add(new Ncm()
                    {
                        CodNcm = txtCodNcm.Text,
                        NomeNcm = txtNomeNcm.Text.ToUpper(),
                        ImpImportacao = Convert.ToDouble(txtImpImportacao.Text),
                        Ipi = Convert.ToDouble(txtIpi.Text),
                        Mva = Convert.ToDouble(txtMva.Text),
                        Autopecas = Convert.ToInt32(chkAutopecas.IsChecked),
                        SemSimilar = Convert.ToInt32(chkSemSimilar.IsChecked)
                        
                    });

                    ctx.SaveChanges();

                    MessageBox.Show(String.Format($"Cadastro efetuado com sucesso!\n NCM {txtCodNcm.Text.ToUpper()} - {txtNomeNcm.Text.ToUpper()}"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    Ncm ncmToUpdate = ncms.Where(n => n.NcmId == Convert.ToInt32(txtNcmId.Text)).FirstOrDefault<Ncm>();
                    ncmToUpdate.CodNcm = txtCodNcm.Text;
                    ncmToUpdate.NomeNcm = txtNomeNcm.Text.ToUpper();
                    ncmToUpdate.ImpImportacao = Convert.ToDouble(txtImpImportacao.Text);
                    ncmToUpdate.Ipi = Convert.ToDouble(txtIpi.Text);
                    ncmToUpdate.Mva = Convert.ToDouble(txtMva.Text);
                    ncmToUpdate.Autopecas = Convert.ToInt32(chkAutopecas.IsChecked);
                    ncmToUpdate.SemSimilar = Convert.ToInt32(chkSemSimilar.IsChecked);

                    ctx.SaveChanges();

                    MessageBox.Show(String.Format($"Cadastro alterado com sucesso!\n NCM {txtCodNcm.Text.ToUpper()} - {txtNomeNcm.Text.ToUpper()}"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            txtCodNcm.Clear();
            txtImpImportacao.Clear();
            txtIpi.Clear();
            txtNcmId.Clear();
            txtNomeNcm.Clear();
            txtMva.Clear();
            chkAutopecas.IsChecked = false;
            chkSemSimilar.IsChecked = false;
            AlterarBotoes(1);
            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtCodNcm.Clear();
            txtImpImportacao.Clear();
            txtIpi.Clear();
            txtNcmId.Clear();
            txtNomeNcm.Clear();
            txtMva.Clear();
            chkAutopecas.IsChecked = false;
            chkSemSimilar.IsChecked = false;
            AlterarBotoes(1);
        }

        public void AlterarBotoes(int op)
        {
            btnNovo.IsEnabled = false;
            btnLocalizar.IsEnabled = false;
            btnAlterar.IsEnabled = false;
            btnExcluir.IsEnabled = false;
            btnSalvar.IsEnabled = false;
            gpbCadastroNcm.IsEnabled = false;

            if (op == 1)
            {
                btnNovo.IsEnabled = true;
                btnLocalizar.IsEnabled = true;
                gpbCadastroNcm.IsEnabled = false;
            }
            if (op == 2)
            {
                btnSalvar.IsEnabled = true;
                btnCancelar.IsEnabled = true;
                gpbCadastroNcm.IsEnabled = true;
            }
            if (op == 3)
            {
                btnAlterar.IsEnabled = true;
                btnExcluir.IsEnabled = true;
                btnCancelar.IsEnabled = true;
                gpbCadastroNcm.IsEnabled = true;
            }

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
