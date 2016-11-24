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
            if ((string)values[0] == "" || (string)values[1] == "")
            {
                return values;
            }
            decimal value1 = System.Convert.ToDecimal(values[0]);
            decimal value2 = System.Convert.ToDecimal(values[1]);
           
            decimal result = value1 * (value2 / 100);

            return System.Convert.ToDecimal(result).ToString(parameter as string);




            //decimal result = 0.00M;
            //List<decimal> fator = new List<decimal>();

            //foreach (var item in values)
            //{
            //    decimal value;
            //    decimal.TryParse(item.ToString(), out value);
            //    fator.Add(value);

            //    for (int i = 0; i < fator.Count; i++)
            //    {
            //        result += result * value;
            //    }
            //}
            //return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
