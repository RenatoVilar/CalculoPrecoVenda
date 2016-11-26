﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace CalculoPrecoVenda
{
    class MultiplyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            decimal result;

            if ((string)values[0] == "" || (string)values[1] == "")
            {
                return values;
            }

            decimal valorNf = System.Convert.ToDecimal(values[0]);
            decimal percentual = System.Convert.ToDecimal(values[1]);
        
            result = valorNf * (percentual / 100);

            return System.Convert.ToDecimal(result).ToString(parameter as string);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
