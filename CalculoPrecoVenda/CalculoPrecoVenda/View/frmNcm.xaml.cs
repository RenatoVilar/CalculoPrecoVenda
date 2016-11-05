using CalculoPrecoVenda.ApplicationServices;
using CalculoPrecoVenda.Model;
using CalculoPrecoVenda.ViewModel;
using MVVMFramework;
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

namespace CalculoPrecoVenda.View 
{
    /// <summary>
    /// Interaction logic for frmNcm.xaml
    /// </summary>
    public partial class frmNcm : Window, IWindowsService
    {
        CalculoPreçoVendaContext ctx = new CalculoPreçoVendaContext();

        //public Ncm Ncm { get; set; }

        public frmNcm()
        {
            InitializeComponent();
            this.DataContext = new NcmViewModel();
        }

        public void CloseWindow()
        {
            throw new NotImplementedException();
        }

        public void ConfirmDelete()
        {
            throw new NotImplementedException();
        }

        public void ConfirmSabe()
        {
            throw new NotImplementedException();
        }

        public void PutFocusOnForm()
        {
            txtCodNcm.Focus();
        }

        public void UpdateBindings()
        {
            txtNcmId.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtCodNcm.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtNomeNcm.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtImpImportacao.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtIpi.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void btnLocalizar_Click(object sender, RoutedEventArgs e)
        {
            frmLocalizarNcm frm = new frmLocalizarNcm();
            frm.ShowDialog();
            if (frm.codigo != 0)
            {
                List<Ncm> _selectedNcm = new List<Ncm>();

                var query = from n in ctx.Ncms
                            where n.NcmId == frm.codigo
                            select n;

                foreach (Ncm ncm in query)
                {
                    _selectedNcm.Add(ncm);
                }

                gpbCadastroNcm.DataContext = _selectedNcm;
               

            }
        }

        
    }
}
