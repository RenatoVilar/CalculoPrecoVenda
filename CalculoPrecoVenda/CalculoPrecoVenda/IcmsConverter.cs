using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;

namespace CalculoPrecoVenda
{
    class IcmsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            decimal result;

            if ((string)values[0] == "" || (string)values[1] == "")
            {
                return string.Empty;
            }

            decimal valorNf = System.Convert.ToDecimal(values[0]);
            decimal percentual = System.Convert.ToDecimal(values[1]);
            bool chkPpb = System.Convert.ToBoolean(values[2]);

            if (chkPpb)
            {
                valorNf = valorNf - (valorNf * (decimal)0.6111);
            }

            result = valorNf * (percentual / 100);

            return System.Convert.ToDecimal(result).ToString(parameter as string);

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
