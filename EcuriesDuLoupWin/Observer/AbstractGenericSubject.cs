using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcuriesDuLoupWin.Observer
{
    public abstract class AbstractGenericSubject<T> : GenericSubject<T>
    {

        protected IList<T> Observers { get; private set; }

        public AbstractGenericSubject()
        {
            this.Observers = new List<T>();
        }

        public void RegisterObserver(T observer)
        {
            this.Observers.Add(observer);
        }
        public void RemoveObserver(T observer)
        {
            this.Observers.Remove(observer);
        }

        public void RegisterObservers(IList<T> observers)
        {
            foreach (T observer in observers)
            {
                this.Observers.Add(observer);
            }

        }
        public void RemoveObservers(IList<T> observers)
        {
            foreach (T observer in observers)
            {
                this.Observers.Remove(observer);
            }
        }
    }
}
