using CalculoPrecoVenda.Model;
using CalculoPrecoVenda.ViewModel;
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
    /// Interaction logic for frmLocalizarNcm.xaml
    /// </summary>
    public partial class frmLocalizarNcm : Window
    {
        public frmLocalizarNcm()
        {
            InitializeComponent();
            this.DataContext = new LocalizarNCMViewModel();
        }

        public int codigo = 0;

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (dtgNcm.SelectedIndex >= 0)
            {
                codigo = dtgNcm.SelectedIndex;
                Close();
            }
        }
    }
}
