using System.Collections;
using System.Collections.Generic;
using caffeServer.Models;
using Microsoft.EntityFrameworkCore;

namespace caffeServer
{
    public interface ICaffeRepository<T>
    {
        IEnumerable Select();
        void Upsert(IEnumerable inputData);
        void Delete(IEnumerable inputData);
    }
}