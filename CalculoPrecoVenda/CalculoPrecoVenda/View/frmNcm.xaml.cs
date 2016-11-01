﻿using System;
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
    public partial class frmNcm : Window
    {
        public frmNcm()
        {
            InitializeComponent();
        }

        private void btnLocalizar_Click(object sender, RoutedEventArgs e)
        {
            frmLocalizarNcm frm = new frmLocalizarNcm();
            frm.ShowDialog();
            frm.Close();
        }
    }
}
