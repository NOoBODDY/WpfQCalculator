using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QueueCalculator;

public class ThreadSaveQueue<T> : Queue<T>, INotifyPropertyChanged
{
    public new void Enqueue(T item)
    {
        lock (this)
        {
            base.Enqueue(item);
            OnPropertyChanged("Count");
        }
    }

    public new T Dequeue()
    {
        lock (this)
        {
            T result = base.Dequeue();
            OnPropertyChanged("Count");
            return result;
        }
    }

    public new int Count
    {
        get
        {
            lock (this)
            {
                return base.Count;
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
}