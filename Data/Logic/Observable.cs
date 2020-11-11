using System;
using System.Collections.Generic;

namespace Data.Logic
{
    public class Observable<T> : IObservable<T>
    {
        private readonly List<IObserver<T>> _observers;

        public Observable() => _observers = new List<IObserver<T>>();

        private readonly struct Unsubscriber : IDisposable
        {
            private readonly Action _unsubscribe;
            public Unsubscriber(Action unsubscribe) { _unsubscribe = unsubscribe; }
            public void Dispose() { _unsubscribe(); }
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(() => _observers.Remove(observer));
        }

        internal void Notify(T subject)
        {
            _observers.ForEach(observer => observer.OnNext(subject));
        }
    }
}