using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;

namespace CalculoPrecoVenda
{
    class SumConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            decimal sum = 0;
            if (values == null)
            {
                return sum;
            }

            foreach (var item in values)
            {
                decimal value;
                if (decimal.TryParse(item.ToString(), out value))
                {
                    sum += value;
                }
            }
            return System.Convert.ToDouble(sum).ToString(parameter as string); 
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

