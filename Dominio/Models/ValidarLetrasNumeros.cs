using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dominio.Models
{
    public class ValidarLetrasNumeros

    {
        public static void validarLetras(KeyPressEventArgs text)
        {

            if (char.IsLetter(text.KeyChar))
            {
                text.Handled = false;
            }
            else if (char.IsSeparator(text.KeyChar))
            {
                text.Handled = false;
            }
            else if (char.IsControl(text.KeyChar))
            {
                text.Handled = false;
            }
            else
            {
                text.Handled = true;
                MessageBox.Show("Ingrese solo letras");
            }
        }




        public static void validarDecimal(KeyPressEventArgs text)
        {
            if (char.IsNumber(text.KeyChar) || char.IsControl(text.KeyChar)
    || text.KeyChar == ',' || text.KeyChar == '.')
            {
                text.Handled = false;
            }
            else
            {
                text.Handled = true;
                MessageBox.Show("Ingrese solo numeros");
                text.Handled = true;
            }
        }


        public static void validarNumeros(KeyPressEventArgs text)
        {

            if (char.IsDigit(text.KeyChar))
            {
                text.Handled = false;
            }
            else
            if (char.IsSeparator(text.KeyChar))
            {
                text.Handled = false;

            }
            else if (char.IsControl(text.KeyChar))
            {
                text.Handled = false;
            }
            else
            {
                text.Handled = true;
                MessageBox.Show("Ingrese solo numeros");
            }

        }
    }
}
