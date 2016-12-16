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
    /// Interaction logic for frmCalculoICMS.xaml
    /// </summary>
    public partial class frmCalculoICMS : Window
    {
        public frmCalculoICMS()
        {
            InitializeComponent();
        }

        public frmCalculoICMS(string valorSugerido1, 
                              string valorSugerido2, 
                              string valorSugerido3, 
                              string valorSugerido4, 
                              string valorSugerido5)
            :this()
        {
            this.txtValorSugerido1.Text = valorSugerido1;
            this.txtValorSugerido2.Text = valorSugerido2;
            this.txtValorSugerido3.Text = valorSugerido3;
            this.txtValorSugerido4.Text = valorSugerido4;
            this.txtValorSugerido5.Text = valorSugerido5;
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
