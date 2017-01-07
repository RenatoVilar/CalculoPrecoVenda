using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;

namespace CalculoPrecoVenda
{
    class SubtractConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            decimal result = 0;

            for (int i = 0; i < values.Length; i++)
            {
                if ((string)values[i] == "")
                {
                    values[i] = "0,00";
                }
            }
            for (int i = 1; i < values.Length; i++)
            {
                decimal sum = System.Convert.ToDecimal(values[i]);

                result += sum;
            }

            decimal valorSugerido = System.Convert.ToDecimal(values[0]);

            result = valorSugerido - result;

            return System.Convert.ToDecimal(result).ToString(parameter as string);
          
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
