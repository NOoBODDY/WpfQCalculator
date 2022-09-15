namespace QueueCalculator.Calculator;

internal class Multiplication: IBinarOperation
{
    public double Execute(double first, double second)
    {
        return first * second;
    }
}