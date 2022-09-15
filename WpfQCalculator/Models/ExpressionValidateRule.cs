using System;
using System.Globalization;
using System.Windows.Controls;

namespace WpfQCalculator.Models;

public class ExpressionValidateRule:ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if ((string)value == String.Empty)
        {
            return new ValidationResult(false, "Expression should not be empty");
        }
        return new ValidationResult(true, null);
    }
}