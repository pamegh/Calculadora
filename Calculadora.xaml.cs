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

        private int primerNumero = 0;
        private String operacion = "";
        private int tipoBase = 10;

        public Calculadora()
        {
            InitializeComponent();

        }

        
        private void BtnNumberOrLetter_Click(object sender, RoutedEventArgs e)
        {

            string valor = (sender as System.Windows.Controls.Button).Content.ToString();

            if (tipoBase == 2 && (valor != "0" && valor != "1"))
            {
                MessageBox.Show("Solo puedes ingresar 0 o 1 en base binaria.", "Error");
                return;
            }
            if (tipoBase == 8 && !("01234567".Contains(valor)))
            {
                MessageBox.Show("Solo puedes ingresar dígitos entre 0 y 7 en base octal.", "Error");
                return;
            }
            if (tipoBase == 16 && !("0123456789ABCDEF".Contains(valor.ToUpper())))
            {
                MessageBox.Show("Solo puedes ingresar dígitos entre 0 y 9, o letras entre A y F en base hexadecimal.", "Error");
                return;
            }

            if (txtContador.Text == "0")
                txtContador.Text = valor;
            else
                txtContador.Text += valor;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtContador.Text = "0";
            primerNumero = 0;
            operacion = "";

            chkBin.IsChecked = false;
            chkOct.IsChecked = false;
            chkDec.IsChecked = false;
            chkHex.IsChecked = false;

            tipoBase = 10;

        }

        private void BtnSuma_Click(object sender, RoutedEventArgs e)
        {
            primerNumero = convertirDecimal(txtContador.Text);
            txtContador.Text = "+";
            operacion = "+";

        }

        private void BtnResta_Click(object sender, RoutedEventArgs e)
        {
            primerNumero = convertirDecimal(txtContador.Text);
            txtContador.Text = "+";
            operacion = "-";


        }

        private void BtnIgual_Click(object sender, RoutedEventArgs e)
        {
            int segundoNumero = convertirDecimal(txtContador.Text);
            int resultado = 0;

            switch (operacion)
            {
                case "+":
                    resultado = primerNumero + segundoNumero;
                    break;
                case "-":
                    resultado = primerNumero - segundoNumero;
                    break;
            }

            txtContador.Text = Decimal(resultado);
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ChkBase_Checked(object sender, RoutedEventArgs e)
        {
            if (txtContador.Text != "0")
            {
                MessageBox.Show("No puedes cambiar la base con un número ya ingresado.", "Advertencia");
                return;
            }

            if (sender is CheckBox checkBox)
            {
                // Mismo comportamiento para mantener una sola base seleccionada
                if (checkBox == chkBin) { chkOct.IsChecked = false; chkDec.IsChecked = false; chkHex.IsChecked = false; }
                else if (checkBox == chkOct) { chkBin.IsChecked = false; chkDec.IsChecked = false; chkHex.IsChecked = false; }
                else if (checkBox == chkDec) { chkBin.IsChecked = false; chkOct.IsChecked = false; chkHex.IsChecked = false; }
                else if (checkBox == chkHex) { chkBin.IsChecked = false; chkOct.IsChecked = false; chkDec.IsChecked = false; }

                tipoBase = checkBox == chkBin ? 2 :
                           checkBox == chkOct ? 8 :
                           checkBox == chkDec ? 10 : 16;
            
        }
        }

        private int convertirDecimal(string ingresado)
        {
            return Convert.ToInt32(ingresado, tipoBase);  
        }

        private string Decimal(int number)
        {
            // Convertir el número de decimal a la base seleccionada
            switch (tipoBase)
            {
                case 2:
                    return Convert.ToString(number, 2);
                case 8:
                    return Convert.ToString(number, 8);
                case 10:
                    return number.ToString();
                case 16:
                    return Convert.ToString(number, 16).ToUpper();
                default:
                    return number.ToString();
            }
        }
    }
}
