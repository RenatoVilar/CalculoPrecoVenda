﻿using System.Globalization;
using System.Windows.Controls;

namespace CalculoPrecoVenda
{
    class ValueIsNotNull : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value as string;

            if (!string.IsNullOrEmpty(str))
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, "Não pode ficar em branco");
            }
        }
    }
}
