namespace QueueCalculator;

public class ShellQCalculator
{
    public Action<string>? UpdateEvent { get; set; }

    public virtual ThreadSaveQueue<Expression> QueueRequests
    {
        get => _queueRequests;
        set => _queueRequests = value;
    }

    public virtual ThreadSaveQueue<double> QueueResults
    {
        get => _queueResults;
        set => _queueResults = value;
    }

    private bool _isRunning;
    protected ThreadSaveQueue<Expression> _queueRequests;
    protected ThreadSaveQueue<double> _queueResults;

    public ShellQCalculator()
    {
        QueueRequests = new ThreadSaveQueue<Expression>();
        QueueResults = new ThreadSaveQueue<double>();
        _isRunning = false;
    }

    public void Start()
    {
        if (!_isRunning)
        {
            _isRunning = true;
            Task.Factory.StartNew(() =>
            {
                while (QueueRequests.Count != 0)
                {
                    Execute();
                }

                _isRunning = false;
            });
        }
    }


    private void Execute()
    {
        Expression expression = QueueRequests.Dequeue();
        Thread.Sleep(expression.Delay);
        Calculator.Calculator calculator = new Calculator.Calculator();
        try
        {
            double result = calculator.Calculate(expression.Input);
            QueueResults.Enqueue(result);
            UpdateEvent?.Invoke(String.Empty);
        }
        catch (Exception e)
        {
            UpdateEvent?.Invoke(e.Message);
        }
    }
}