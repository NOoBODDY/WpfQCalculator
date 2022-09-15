using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using QueueCalculator;
using WpfQCalculator.Models;

namespace WpfQCalculator.ViewModels;

public sealed class MainViewModel: INotifyPropertyChanged
{
    private UiShellQCalculator _qCalculator;

    public UiShellQCalculator QCalculator
    {
        get => _qCalculator;
        set
        {
            _qCalculator = value;
            OnPropertyChanged();
        }
    }

    private SynchronizationContext _synchronizationContext;
    

    private ExpressionModel _newExpression;
    
    public ExpressionModel NewExpression
    {
        get => _newExpression;
        set
        {
            _newExpression = value;
            OnPropertyChanged();
        }
    }

    


    


    public RelayCommand AddToQCommand
    {
        get
        {
            return new RelayCommand((object obj) =>
            {
                if (NewExpression.Expression != String.Empty && NewExpression.ThreadDelay != 0)
                {
                    Expression expression = new Expression(NewExpression.Expression, NewExpression.ThreadDelay);
                    NewExpression = new ExpressionModel();
                    QCalculator.QueueRequests.Enqueue(expression);
                    QCalculator.Start();
                }
            });
        }
    }

    

    public MainViewModel()
    {
        _synchronizationContext = SynchronizationContext.Current;
        QCalculator = new UiShellQCalculator(_synchronizationContext);
        _newExpression = new ExpressionModel();

    }
    
    
    #region Inerface

    public event PropertyChangedEventHandler? PropertyChanged;


    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}