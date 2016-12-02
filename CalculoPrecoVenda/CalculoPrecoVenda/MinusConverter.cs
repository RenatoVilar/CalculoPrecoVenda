using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;

namespace CalculoPrecoVenda
{
    class MinusConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {

            if ((string)values[0] == "" || (string)values[1] == "")
            {
                return string.Empty;
            }

            decimal value1 = System.Convert.ToDecimal(values[0]);
            decimal value2 = System.Convert.ToDecimal(values[1]);

            decimal result = value1 - value2;

            return System.Convert.ToDecimal(result).ToString(parameter as string);
          
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
