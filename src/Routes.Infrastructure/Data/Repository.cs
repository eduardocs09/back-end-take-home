using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Routes.Core.Interfaces;
using Routes.Core.Base;

namespace Routes.Infrastructure.Data
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _dbContext;
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<T> List<T>() where T : Entity
        {
            return _dbContext.Set<T>().ToList();
        }

        public int AddRange<T>(T[] entities) where T : Entity
        {
            _dbContext.Set<T>().AddRange(entities);
            _dbContext.SaveChanges();
            return entities.Count();
        }

        public void RemoveAll<T>() where T : Entity
        {
            var entities = _dbContext.Set<T>().ToArray();
            _dbContext.Set<T>().RemoveRange(entities);
            _dbContext.SaveChanges();
        }
    }
}
