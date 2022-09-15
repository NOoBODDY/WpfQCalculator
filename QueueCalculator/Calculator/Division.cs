namespace QueueCalculator.Calculator;

internal class Division: IBinarOperation
{
    public double Execute(double first, double second)
    {
        return first / second;
    }
}