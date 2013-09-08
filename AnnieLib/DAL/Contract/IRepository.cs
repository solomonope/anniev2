using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace BitworkSystem.Annie.DAL.Contract
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All
        {
            get;
        }
        bool Save(T _T);
        T GetById(string Id);
        IQueryable<T> Search(Expression<Func<T, bool>> predicate);
        bool Delete(T _T);
		bool Update(T _T);
    }
}
