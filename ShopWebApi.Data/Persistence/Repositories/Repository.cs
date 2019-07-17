using ShopWebApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopWebApi.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Uses Entity FRamework DbContext
        /// </summary>
        protected readonly DbContext Context;


        /// <summary>
        /// Reads in the repository from the DbContext
        /// </summary>
        /// <param name="context"></param>
        public Repository(DbContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Adds the  product to the database 
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        /// <summary>
        /// Gets the product from the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the product from with a particular range</returns>
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        /// <summary>
        /// Gets all prodcuts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }
        /// <summary>
        /// Remove a product from the database
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        /// <summary>
        /// Update a product with a particular Id
        /// </summary>
        /// <param name="id"></param>
        public void Update(int id)
        {
            Context.Entry(Context).State = EntityState.Modified;
        }

        public void Update(TEntity entity)
        {
            Context.Entry(Context).State = EntityState.Modified;
        }
    }
}