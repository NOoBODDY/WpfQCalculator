namespace QueueCalculator.Calculator;

public class Subtraction: IBinarOperation
{
    public double Execute(double first, double second)
    {
        return first - second; 
    }
}