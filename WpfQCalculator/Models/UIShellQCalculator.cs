using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using QueueCalculator;

namespace WpfQCalculator.Models;

public class UiShellQCalculator: ShellQCalculator, INotifyPropertyChanged
{
    public override ThreadSaveQueue<double> QueueResults
    {
        get => _queueResults;
        set
        {
            _queueResults = value;
            OnPropertyChanged();
        }
    }
    

    public override ThreadSaveQueue<Expression> QueueRequests
    {
        get => _queueRequests;
        set
        {
            _queueRequests = value;
            OnPropertyChanged();
        }
    }

    private ObservableCollection<string> _results;
    public ObservableCollection<string> Results
    {
        get => _results;
        set
        {
            _results = value;
            OnPropertyChanged();
        }
    }

    private SynchronizationContext _synchronizationContext;
    
    public UiShellQCalculator(SynchronizationContext synchronizationContext):base()
    {
        _synchronizationContext = synchronizationContext;
        this.UpdateEvent += UpdateParams;
        Results = new ObservableCollection<string>();
    }

    private void UpdateParams(string message)
    {
        _synchronizationContext.Send(
            (state =>
            {
                if (message == String.Empty)
                {
                    Results.Add(this._queueResults.Dequeue().ToString());
                }
                else
                {
                    Results.Add(message);
                }
            }), null);
        

    }
    
    

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
}