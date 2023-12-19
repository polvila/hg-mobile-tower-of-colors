using System;
using System.Collections.Generic;

public class EventSystemService : Singleton<EventSystemService>
{
    private readonly Dictionary<Type, Delegate> _events = new();

    public void Subscribe<TEvent>(Action<TEvent> callback)
    {
        var eventType = typeof(TEvent);
        if (!_events.ContainsKey(eventType))
        {
            _events[eventType] = callback;
        }
        else
        {
            _events[eventType] = Delegate.Combine(_events[eventType], callback);
        }
    }

    public void Unsubscribe<TEvent>(Action<TEvent> callback)
    {
        var eventType = typeof(TEvent);
        if (!_events.ContainsKey(eventType)) return;
		
        _events[eventType] = Delegate.Remove(_events[eventType], callback);
        if (_events[eventType] == null)
        {
            _events.Remove(eventType);
        }
    }

    public void Dispatch<TEvent>(TEvent eventData)
    {
        var eventType = typeof(TEvent);
        if (!_events.TryGetValue(eventType, out var eventDelegate)) return;

        if (eventDelegate is Action<TEvent> action)
        {
            action(eventData);
        }
        else
        {
            throw new InvalidOperationException(
                $"Incompatible delegate type for event {eventType}. Expected delegate of type Action<{eventType}>.");
        }
    }
}
