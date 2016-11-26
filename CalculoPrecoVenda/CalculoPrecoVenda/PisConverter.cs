using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;

namespace CalculoPrecoVenda
{
    class PisConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool radForEstrangeiro = (bool)values[0];
            bool chkPecas = (bool)values[1];

            if (radForEstrangeiro && chkPecas)
            {
                return 3.12.ToString(parameter as string);
            }
            else if (radForEstrangeiro)
            {
                return 2.1.ToString(parameter as string);

            }
            
            return 0.00.ToString(parameter as string);

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
