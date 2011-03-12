using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcuriesDuLoupWin
{
    public interface GenericSubject<T>
    {
        void RegisterObserver(T webExceptionObserver);
        void RemoveObserver(T webExceptionObserver);
        void RegisterObservers(IList<T> webExceptionObserver);
        void RemoveObservers(IList<T> webExceptionObserver);
    }
}
