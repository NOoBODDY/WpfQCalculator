using System.Text.RegularExpressions;

namespace QueueCalculator.Calculator;

public class Calculator
{
    private readonly Regex _regex;
    public Calculator()
    {
        string pattern = @"(?<NUM>\d+[,]?\d+)+|(?<OP>[+]{1}|[-]{1}|[*]{1}|[/]{1})";
        _regex = new Regex(pattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
    }
    public double Calculate(string input)
    {
        var matches = _regex.Matches(input);
        if (matches.Count != 3)
            throw new ArgumentException("Bad expression");
        IBinarOperation operation = BinarOperationsFabric.GetOperation(matches[1].Value);
        return operation.Execute(Double.Parse(matches[0].Value), Double.Parse(matches[2].Value));
    }
}