using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Veegan.Data.Access.Repository.IRepository
{
    public interface IRepository<T> where T : class


    {
        // Get ALL, GET BY ID First or DEFAULT , ADD, REMOVE , REMOVE RANGE

        //these are the generic definitions

        void Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);


        //incase we wants to get a list of products
        IEnumerable<T> GetAll();

        //T is the generic key used in the repo
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null);
    }
}
