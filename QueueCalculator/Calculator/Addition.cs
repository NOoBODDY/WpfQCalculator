namespace QueueCalculator.Calculator;

internal class Addition : IBinarOperation
{
    public double Execute(double first, double second)
    {
        return first + second;
    }
}