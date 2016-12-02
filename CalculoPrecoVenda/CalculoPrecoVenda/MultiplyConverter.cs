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

            for (int i = 0; i < values.Length-1; i++)
            {
                if ((string)values[i] == "")
                {
                    values[i] = "0,00";
                }

                double sum = System.Convert.ToDouble(values[i]);
                result += sum;
            }

            //if ((string)values[0] == "" || (string)values[1] == "")
            //{
            //    return values;
            //}

            //decimal valorNf = System.Convert.ToDecimal(values[0]);
            //decimal valorFrete = System.Convert.ToDecimal(values[1]);
            //decimal percentual = System.Convert.ToDecimal(values[2]);

            //result = (valorNf + valorFrete) * (percentual / 100);

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
