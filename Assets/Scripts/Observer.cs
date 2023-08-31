using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer : MonoBehaviour
{
    public abstract void OnNotify(object Value);
}
public abstract class Subject : MonoBehaviour
{
    private List<Observer> _observers=new List<Observer>();
    public void RegisterObserver(Observer observer)
    {
        _observers.Add(observer);
    }
    public void UnregisterObserver(Observer observer)
    {
        _observers.Remove(observer);
    }
    public void Notify(object value)
    {
        foreach (Observer observer in _observers)
        {
            observer.OnNotify(value);
        }
    }
}
