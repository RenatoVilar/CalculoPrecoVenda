using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CalculoPrecoVenda
{
    class CalcPrecoReposicaoConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            decimal result;

            if ((string)values[0] == "" || (string)values[1] == "" || (string)values[2] == "")
            {
                return "0,00";
            }

            decimal custoReposicao = System.Convert.ToDecimal(values[0]);
            decimal totalImpostos = System.Convert.ToDecimal(values[1]) / 100;
            decimal margemLucro = System.Convert.ToDecimal(values[2]) / 100;
            

            result = custoReposicao / (1 - (totalImpostos + margemLucro));

            return System.Convert.ToDecimal(result).ToString(parameter as string);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
