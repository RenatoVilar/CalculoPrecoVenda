using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace CalculoPrecoVenda
{
    class MultiplyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double result = 0;

            if (values == null )
            {
                return result;
            }

            for (int i = 0; i < values.Length; i++)
            {
                if ((string)values[i] == "")
                {
                    values[i] = "0,00";
                }
            }

            for (int i = 0; i < values.Length-1; i++)
            {
                double sum = System.Convert.ToDouble(values[i]);

                result += sum;
            }

            double percentual = System.Convert.ToDouble(values[values.Length - 1]) / 100;

            result = result * percentual;

            return System.Convert.ToDecimal(result).ToString(parameter as string);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
