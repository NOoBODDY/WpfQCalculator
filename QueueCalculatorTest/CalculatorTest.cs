using QueueCalculator.Calculator;

namespace QueueCalculatorTest;

public class UnitTest1
{
    [Fact]
    public void IntegerTest()
    {
        Calculator calculator = new Calculator();
        string input1 = "1234 +321";
        string input2 = "1234*321";
        string input3 = "1234/ 321";
        string input4 = "1234 - 321";
        string input5 = "321 / 1234";
        
        Assert.Equal(1234 +321, calculator.Calculate(input1));
        Assert.Equal(1234*321, calculator.Calculate(input2));
        Assert.Equal(1234.0 / 321, calculator.Calculate(input3));
        Assert.Equal(1234 - 321, calculator.Calculate(input4));
        Assert.Equal(321.0 / 1234, calculator.Calculate(input5));
    }

    [Fact]
    public void DoubleTest()
    {
        Calculator calculator = new Calculator();
        string input1 = "1234,2 +321,4";
        string input2 = "1234,2*321,4";
        string input3 = "1234,2/ 321,4";
        string input4 = "1234,2 - 321,4";
        string input5 = "321,2 / 1234,4";
        
        Assert.Equal(1234.2 +321.4, calculator.Calculate(input1));
        Assert.Equal(1234.2*321.4, calculator.Calculate(input2));
        Assert.Equal(1234.2/ 321.4, calculator.Calculate(input3));
        Assert.Equal(1234.2 - 321.4, calculator.Calculate(input4));
        Assert.Equal(321.2 / 1234.4, calculator.Calculate(input5));
    }

    [Fact]
    public void ExceptionTest()
    {
        Calculator calculator = new Calculator();
        string input1 = "1234,2 +321,4 - 123";
        string input2 = "1234,2**321,4";
        string input3 = "1234,2-- 321,4";
        string input4 = "1234,2 -123 321,4";
        string input5 = "321,2  1234,4";
        
        Assert.ThrowsAny<Exception>(()=>calculator.Calculate(input1));
        Assert.ThrowsAny<Exception>(()=>calculator.Calculate(input2));
        Assert.ThrowsAny<Exception>(()=>calculator.Calculate(input3));
        Assert.ThrowsAny<Exception>(()=>calculator.Calculate(input4));
        Assert.ThrowsAny<Exception>(()=>calculator.Calculate(input5));
    }
}