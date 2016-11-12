using CalculoPrecoVenda.ApplicationServices;
using CalculoPrecoVenda.Model;
using CalculoPrecoVenda.ViewModel;
using MVVMFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            ncm.ErrorsChanged += OnErrorChanged;
            gridNcm.DataContext = ncm;

            operacao = "Novo";

            ncm.ErrorsChanged += (s, a) =>
            {
                INotifyDataErrorInfo info = s as INotifyDataErrorInfo;
                btnSalvar.IsEnabled = !info.HasErrors;
            };

            AlterarBotoes(2);
            
        }

        private void OnErrorChanged(object sender, DataErrorsChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnLocalizar_Click(object sender, RoutedEventArgs e)
        {
            ncm = new Ncm();

            frmLocalizarNcm frm = new frmLocalizarNcm();
          
            frm.ShowDialog();
            AlterarBotoes(3);

            ncm = frm.selectedNcm;

            gridNcm.DataContext = ncm;
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            operacao = "Alterar";
            AlterarBotoes(2);
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var ncms = ctx.Ncms.ToList<Ncm>();

            if (operacao == "Novo")
            {
                ctx.Ncms.Add(new Ncm()
                {
                    CodNcm = txtCodNcm.Text,
                    NomeNcm = txtNomeNcm.Text,
                    ImpImportacao = Convert.ToDouble(txtImpImportacao.Text),
                    Ipi = Convert.ToDouble(txtIpi.Text)
                });

                ctx.SaveChanges();

                MessageBox.Show(String.Format($"Cadastro efetuado com sucesso!\n NCM {txtCodNcm.Text} - {txtNomeNcm.Text}"));
            }
            else
            {
                Ncm ncmToUpdate = ncms.Where(n => n.NcmId == Convert.ToInt32(txtNcmId.Text)).FirstOrDefault<Ncm>();
                ncmToUpdate.CodNcm = txtCodNcm.Text;
                ncmToUpdate.NomeNcm = txtNomeNcm.Text;
                ncmToUpdate.ImpImportacao = Convert.ToDouble(txtImpImportacao.Text);
                ncmToUpdate.Ipi = Convert.ToDouble(txtIpi.Text);

                ctx.SaveChanges();

                MessageBox.Show(String.Format($"Cadastro alterado com sucesso!\n NCM {txtCodNcm.Text} - {txtNomeNcm.Text}"));
            }

            LimparTela(this);
            AlterarBotoes(1);
            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimparTela(this);
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

        public void LimparTela(Control controles)
        {
            //foreach (Control ctrl in this.Controls)
            //{
            //    if (ctrl is TextBox)
            //    {
            //        ((TextBox)ctrl).Text = String.Empty;
            //    }
            //    if (ctrl is CheckBox)
            //    {
            //        ((CheckBox)ctrl).IsChecked = false;
            //    }
            //    if (ctrl is ComboBox)
            //    {
            //        ((ComboBox)ctrl).SelectedIndex = -1;
            //    }
            //    else if (ctrl.Controls.Count > 0)
            //    {
            //        LimparTela(ctrl);
            //    }
            //}
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            //gpbCadastroNcm.DataContext = selectedNcm;
        }

        private void OnValidationError(object sender, ValidationErrorEventArgs args)
        {
            string error = args.Error.ErrorContent.ToString();
            MessageBox.Show(this, error, "Erro de validação", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
