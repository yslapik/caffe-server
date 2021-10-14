using System;
using System.Collections;

namespace caffeServer
{
    public interface ICaffeRepository<out T>
    {
        IEnumerable Select();
        IEnumerable Select(Func<T, bool> predicate);
        void Upsert(IEnumerable inputData);
        void Delete(IEnumerable inputData);
    }
}