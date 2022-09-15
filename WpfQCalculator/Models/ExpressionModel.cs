using System;
using System.ComponentModel;

namespace WpfQCalculator.Models;

public class ExpressionModel
{
    public string Expression { get; set; }
    public int ThreadDelay { get; set; }
    

    public ExpressionModel()
    {
        Expression = String.Empty;
        ThreadDelay = 1;
    }
}