namespace QueueCalculator;

public class Expression
{
    internal string Input;
    internal int Delay;

    public Expression(string expression, int sleepDelay)
    {
        Input = expression;
        Delay = sleepDelay;
    }
}