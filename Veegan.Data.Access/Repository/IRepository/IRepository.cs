﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Veegan.Data.Access.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {

        //GET ALL, GET BY ID FIRST OR DEFAULT , ADD, REMOVE, REMOVE RANGE 

        void Add(T entity);


        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);

        // adding api props
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
            string? includeProperties = null);



        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

    }
}