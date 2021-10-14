using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using caffeServer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

        private void UpsertDataList(IEnumerable<T> datalist)
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
        
        private IEnumerable<T> DeserializeInput<T>(IEnumerable inputData)
        {
            return (from JsonElement element in inputData
                select element.GetRawText()
                into json
                select JsonConvert.DeserializeObject<T>(json));
        }

        public IEnumerable Select()
        {
            return _dbSet.AsNoTracking().ToArray();
        }

        public IEnumerable Select(Func<T, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToArray();
        }

        public void Delete(IEnumerable inputData)
        {
            var dataList = DeserializeInput<T>(inputData);
            _dbSet.RemoveRange(dataList);
            _dbContext.SaveChanges();
        }

        public void Upsert(IEnumerable inputData)
        {
            var dataList = DeserializeInput<T>(inputData);
            UpsertDataList(dataList);
        }
    }
}