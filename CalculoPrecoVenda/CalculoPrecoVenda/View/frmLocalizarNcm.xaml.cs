using CalculoPrecoVenda.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CalculoPrecoVenda.View
{
    /// <summary>
    /// Interaction logic for frmLocalizarNcm.xaml
    /// </summary>
    public partial class frmLocalizarNcm : Window
    {
        CalculoPreçoVendaContext ctx = new CalculoPreçoVendaContext();

        public Ncm selectedNcm;
        public frmLocalizarNcm()
        {
            InitializeComponent();
            
        }
            
        public int codigo = 0;

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {

            List<Ncm> ncms = new List<Ncm>();

            int indexCboBox = cboLocalizarNCM.SelectedIndex;

            if (indexCboBox == 0) // 0 = NCM | 1 = Descrição
            {
                var query = from n in ctx.Ncms
                            where n.CodNcm.Contains(txtPesquisa.Text)
                            select n;

                ncms = query.ToList();
               
            }
            else if (indexCboBox == 1)
            {
                var query = from n in ctx.Ncms
                            where n.NomeNcm.Contains(txtPesquisa.Text)
                            select n;

                ncms = query.ToList();
                
            }

            if (ncms.Count == 0)
            {
                MessageBox.Show("Nenhum item encontrado!");
            }

            dtgNcm.ItemsSource = ncms;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            selectedNcm = new Ncm();

            selectedNcm = (Ncm)dtgNcm.SelectedValue;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboLocalizarNCM.Items.Add("NCM");
            cboLocalizarNCM.Items.Add("Descrição");
            cboLocalizarNCM.SelectedIndex = 0;
        }
    }
}
