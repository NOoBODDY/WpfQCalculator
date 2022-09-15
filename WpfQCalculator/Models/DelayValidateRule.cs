using System;
using System.Globalization;
using System.Windows.Controls;

namespace WpfQCalculator.Models;

public class DelayValidateRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {

        int delay = 0;

        try
        {
            delay = Int32.Parse((string)value);
        }
        catch (Exception e)
        {
            return new ValidationResult(false, "Unacceptable symbols.");
        }

        if (delay <= 0)
        {
            return new ValidationResult(false, "Delay must be greater then zero.");
        }
        return new ValidationResult(true, null);
        
    }
}