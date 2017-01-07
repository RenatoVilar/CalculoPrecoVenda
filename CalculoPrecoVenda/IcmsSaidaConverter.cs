using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;

namespace CalculoPrecoVenda
{
    class IcmsSaidaConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            decimal result;

            if ((string)values[0] == "" || (string)values[1] == "")
            {
                return "0,00";
            }

            decimal valorSugerido = System.Convert.ToDecimal(values[0]);
            decimal percentual = System.Convert.ToDecimal(values[1]);
            bool chkPpb = System.Convert.ToBoolean(values[2]);
            bool radPessoaFisica = System.Convert.ToBoolean(values[3]);
            bool chkClienteZfm = System.Convert.ToBoolean(values[4]);
            bool radClienteNacional = System.Convert.ToBoolean(values[5]);
            bool chkImportadoZfm = System.Convert.ToBoolean(values[6]);
            bool radClienteLocal = System.Convert.ToBoolean(values[7]);

            if (chkPpb && radPessoaFisica && radClienteNacional)
            {
                valorSugerido = valorSugerido - (valorSugerido * (decimal)0.41665);
            }

            if (chkImportadoZfm && chkClienteZfm || chkPpb && radClienteLocal)
            {
                valorSugerido = valorSugerido - (valorSugerido * (decimal)0.6111);
            }

            result = valorSugerido * (percentual / 100);

            return System.Convert.ToDecimal(result).ToString(parameter as string);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
