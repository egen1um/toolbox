using System;
using System.Collections.Generic;

public interface ISignal
{
}

/* Things to remember:
 
- Dispatched object is common for all the listeners, so changing it in earlier listener will change it for other listeners 

*/

public class Signal : ISignal
{
    private readonly List<Action> _listeners = new List<Action>();
    private readonly List<Action> _onceListeners = new List<Action>();

    private bool _isDispatching;

    public void Add(Action listener)
    {
        _listeners.Add(listener);
    }

    public void AddOnce(Action listener)
    {
        _onceListeners.Add(listener);
    }

    public void Remove(Action listener)
    {
        _listeners.RemoveAll(l => l.Equals(listener));
        _onceListeners.RemoveAll(l => l.Equals(listener));
    }

    public void RemoveAll()
    {
        _listeners.Clear();
        _onceListeners.Clear();
    }

    public void Dispatch()
    {
        _isDispatching = true;

        _listeners.ForEach(l => l());
        _onceListeners.ForEach(l => l());

        _onceListeners.Clear();

        _isDispatching = false;
    }
}

public class Signal<T> : ISignal
{
    private readonly List<Action<T>> _listeners = new List<Action<T>>();
    private readonly List<Action<T>> _onceListeners = new List<Action<T>>();

    public void Add(Action<T> listener)
    {
        _listeners.Add(listener);
    }

    public void AddOnce(Action<T> listener)
    {
        _onceListeners.Add(listener);
    }

    public void Remove(Action<T> listener)
    {
        _listeners.RemoveAll(l => l.Equals(listener));
        _onceListeners.RemoveAll(l => l.Equals(listener));
    }

    public void RemoveAll()
    {
        _listeners.Clear();
        _onceListeners.Clear();
    }

    public void Dispatch(T t)
    {
        _listeners.ForEach(l => l(t));
        _onceListeners.ForEach(l => l(t));

        _onceListeners.Clear();
    }
}

public class Signal<T, T1> : ISignal
{
    private readonly List<Action<T, T1>> _listeners = new List<Action<T, T1>>();
    private readonly List<Action<T, T1>> _onceListeners = new List<Action<T, T1>>();

    public void Add(Action<T, T1> listener)
    {
        _listeners.Add(listener);
    }

    public void AddOnce(Action<T, T1> listener)
    {
        _onceListeners.Add(listener);
    }

    public void Remove(Action<T, T1> listener)
    {
        _listeners.RemoveAll(l => l.Equals(listener));
        _onceListeners.RemoveAll(l => l.Equals(listener));
    }

    public void RemoveAll()
    {
        _listeners.Clear();
        _onceListeners.Clear();
    }

    public void Dispatch(T t, T1 t1)
    {
        _listeners.ForEach(l => l(t, t1));
        _onceListeners.ForEach(l => l(t, t1));

        _onceListeners.Clear();
    }
}

public class Signal<T, T1, T2> : ISignal
{
    private readonly List<Action<T, T1, T2>> _listeners = new List<Action<T, T1, T2>>();
    private readonly List<Action<T, T1, T2>> _onceListeners = new List<Action<T, T1, T2>>();

    public void Add(Action<T, T1, T2> listener)
    {
        _listeners.Add(listener);
    }

    public void AddOnce(Action<T, T1, T2> listener)
    {
        _onceListeners.Add(listener);
    }

    public void Remove(Action<T, T1, T2> listener)
    {
        _listeners.RemoveAll(l => l.Equals(listener));
        _onceListeners.RemoveAll(l => l.Equals(listener));
    }

    public void RemoveAll()
    {
        _listeners.Clear();
        _onceListeners.Clear();
    }

    public void Dispatch(T t, T1 t1, T2 t2)
    {
        _listeners.ForEach(l => l(t, t1, t2));
        _onceListeners.ForEach(l => l(t, t1, t2));

        _onceListeners.Clear();
    }
}

public class Signal<T, T1, T2, T3> : ISignal
{
    private readonly List<Action<T, T1, T2, T3>> _listeners = new List<Action<T, T1, T2, T3>>();
    private readonly List<Action<T, T1, T2, T3>> _onceListeners = new List<Action<T, T1, T2, T3>>();

    public void Add(Action<T, T1, T2, T3> listener)
    {
        _listeners.Add(listener);
    }

    public void AddOnce(Action<T, T1, T2, T3> listener)
    {
        _onceListeners.Add(listener);
    }

    public void Remove(Action<T, T1, T2, T3> listener)
    {
        _listeners.RemoveAll(l => l.Equals(listener));
        _onceListeners.RemoveAll(l => l.Equals(listener));
    }

    public void RemoveAll()
    {
        _listeners.Clear();
        _onceListeners.Clear();
    }

    public void Dispatch(T t, T1 t1, T2 t2, T3 t3)
    {
        _listeners.ForEach(l => l(t, t1, t2, t3));
        _onceListeners.ForEach(l => l(t, t1, t2, t3));

        _onceListeners.Clear();
    }
}