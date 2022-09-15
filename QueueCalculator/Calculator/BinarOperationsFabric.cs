namespace QueueCalculator.Calculator;

internal class BinarOperationsFabric
{
    public static  IBinarOperation GetOperation(string operationSymbol)
    {
        switch (operationSymbol)
        {
            case "+":
                return new Addition();
            case "-":
                return new Subtraction();
            case "*":
                return new Multiplication();
            case "/":
                return new Division();
            default:
                throw new ArithmeticException($"Invalid operation: {operationSymbol}");
        }
    }
}