using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace caffeServer
{
    public interface ICaffeRepository<T>
    {
        IEnumerable<T> SelectDataList();
        void UpsertDataList(T[] datalist);
        void RemoveDataList(T[] datalist);
    }
}