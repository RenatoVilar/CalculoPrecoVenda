using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CalculoPrecoVenda
{
    class TotalImpostosConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double sum = 0;
            if ((string)values[0] == "" || (string)values[1] == "" || (string)values[2] == "" || (string)values[4] == "")
            {
                return "0,00";
            }

            if (values == null)
            {
                return sum;
            }

            double txtPercentIcmsVendas = System.Convert.ToDouble(values[0]);
            double txtPercentDifal = System.Convert.ToDouble(values[1]);
            double txtPercentFcp = System.Convert.ToDouble(values[2]);
            double txtPercentImpostosFed = System.Convert.ToDouble(values[3]);
            double txtPercentDesOperacinais = System.Convert.ToDouble(values[4]);
            bool Ppb = System.Convert.ToBoolean(values[5]);
            bool ClienteLocal = System.Convert.ToBoolean(values[6]);
            bool ClienteNacional = System.Convert.ToBoolean(values[7]);
            bool PessoaFisica = System.Convert.ToBoolean(values[8]);
            bool ImportadoZfm = System.Convert.ToBoolean(values[9]);
            bool ClienteZfm = System.Convert.ToBoolean(values[10]);


            sum = txtPercentIcmsVendas + txtPercentDifal + txtPercentFcp + txtPercentImpostosFed + txtPercentDesOperacinais;

            if ((Ppb && ClienteLocal) || (ImportadoZfm && ClienteZfm))
            {
                sum = sum - 11;
            }

            if (Ppb && ClienteNacional && PessoaFisica)
            {
                sum = sum - 5;
            }

            return System.Convert.ToDouble(sum).ToString(parameter as string);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
   
}
