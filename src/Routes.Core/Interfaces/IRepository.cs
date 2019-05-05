using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Routes.Core.Base;

namespace Routes.Core.Interfaces
{
    public interface IRepository
    {
        List<T> List<T>() where T : Entity;
        List<T> List<T>(params Expression<Func<T, object>>[] includes) where T : Entity;
        int AddRange<T>(T[] entities) where T : Entity;
        void RemoveAll<T>() where T : Entity;
    }
}
