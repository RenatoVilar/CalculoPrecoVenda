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
    class AliquotaIcmsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((UnidadeFederada)values[14] == null)
            {
                return 0.00.ToString(parameter as string);
            }

            bool forEstrangeiro = (bool)values[0];
            bool forNacional = (bool)values[1];
            bool forLocal = (bool)values[2];
            bool microempresa = (bool)values[3];
            bool prodEstrangeiro = (bool)values[4];
            bool prodNacional = (bool)values[5];
            bool motorAte90Hp = (bool)values[6];
            bool motorAcima90Hp = (bool)values[7];
            bool pecas = (bool)values[8];
            bool embarcacoes = (bool)values[9];
            bool corredor = (bool)values[10];
            bool importadoZfm = (bool)values[11];
            bool substTribuitaria = (bool)values[12];
            bool ppb = (bool)values[13];
            UnidadeFederada unidadeFederada = (UnidadeFederada)values[14];

            if (microempresa)
            {
                return Settings.Default.AliquotaIcmsMicro.ToString(parameter as string);
            }
            else if (substTribuitaria)
            {
                return 0.00.ToString(parameter as string);
            }
            else if (embarcacoes && forLocal && ppb)
            {
                return unidadeFederada.AliquotaInterna.ToString(parameter as string);
            }
            else if (embarcacoes && forLocal)
            {
                return unidadeFederada.AliquotaEmbarcacoes.ToString(parameter as string);
            }
            else if (forNacional && prodEstrangeiro)
            {
                return Settings.Default.AliquotaIcmsInterImportados.ToString(parameter as string);
            }
            else if (forLocal )
            {
                return unidadeFederada.AliquotaInterna.ToString(parameter as string);
            }

            return unidadeFederada.AliquotaInterestadual.ToString(parameter as string);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {

            return new[] { value, Binding.DoNothing };
        }
    }
}
