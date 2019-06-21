﻿using MVCProductsChallenge.Context;
using MVCProductsChallenge.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProductsChallenge.Services
{
    public interface IBaseService<T>
    {
        void Create(T entity);
        void Delete(T entity);
        T Get(int id);
        IQueryable<T> List();
        void Update(T oldEntity, T newEntity);
    }

    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly ProductsContext _dbContext;

        public BaseService()
        {
            _dbContext = new ProductsContext();
        }

        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public T Get(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IQueryable<T> List()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public void Update(T oldEntity, T newEntity)
        {
            _dbContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            _dbContext.SaveChanges();
        }
    }
}
