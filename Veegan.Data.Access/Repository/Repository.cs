using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Veegan.Data.Access.Repository.IRepository;
using Vegan.DataAccess.Data;

namespace Veegan.Data.Access.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            // this will allows us to map FoodType and Categpry
           _db.MenuItem.Include(u => u.FoodType).Include(u => u.Category);
            this.dbSet = db.Set<T>();
        }


        public void Add(T entity)
        {
            // to add new things in the DB with Repository
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(string? includeProperties=null)
        {
            // we will query all the items that we want to return
            IQueryable<T> query = dbSet;
            if( includeProperties != null)
            {

                //
                //adding properties for API call in MenuItems this will split our output abc,,xyz => to abc xyz
                foreach(var includeProperty in includeProperties.Split(
                    new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    //to include the things in the query
                    query = query.Include(includeProperty);
                }
            }
            return query.ToList();

        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null)
        {
            // First Or Default uses Lambda Functions
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();

        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);

        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);

        }
    }
}