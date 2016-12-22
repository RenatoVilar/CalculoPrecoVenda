using CalculoPrecoVenda.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CalculoPrecoVenda
{
    class DifalConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((UnidadeFederada)values[3] == null)
            {
                return 0.00.ToString(parameter as string);
            }

            if ((string)values[2] == "")
            {
                values[2] = "0,00";
            }

            bool pessoaFisica = (bool)values[0];
            bool clienteNacional = (bool)values[1];
            double alInterestadual = System.Convert.ToDouble(values[2]);
            UnidadeFederada unidadeFederada = (UnidadeFederada)values[3];

            double alInternaUfDestino = unidadeFederada.AliquotaInterna;

            double difal = alInternaUfDestino - alInterestadual;

            if (pessoaFisica && clienteNacional)
            {
                return difal.ToString(parameter as string);
            }

            return 0.00.ToString(parameter as string);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
