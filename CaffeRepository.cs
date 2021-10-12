using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace caffeServer
{
    public class CaffeRepository<T>:ICaffeRepository<T> where T:class
    {
        DbContext _dbContext;
        DbSet<T> _dbSet;
        public CaffeRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public IEnumerable<T> SelectDataList()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public void UpsertDataList(T[] datalist)
        {
            var positions = _dbSet.AsNoTracking().ToArray();
            IEnumerable<T> newPositions = datalist.Except(positions);
            IEnumerable<T> modifiedPositions = datalist.Except(newPositions);
            if (newPositions.Any())
            {
                _dbSet.AddRange(newPositions);
            } 
            if (modifiedPositions.Any())
            {
                _dbSet.UpdateRange(modifiedPositions);
            }
            _dbContext.SaveChanges();
        }

        public void RemoveDataList(T[] datalist)
        {
            _dbSet.RemoveRange(datalist);
            _dbContext.SaveChanges();
        }
    }
}