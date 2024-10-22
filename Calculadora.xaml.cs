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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculadora.VISTA
{
    /// <summary>
    /// Lógica de interacción para Calculadora.xaml
    /// </summary>
    public partial class Calculadora : Window
    {

        String resultado;
        public Calculadora()
        {
            InitializeComponent();
            

            btnAC.Click += BtnAC_Click;
            

        }

        private void BtnAC_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void botonMenos_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
