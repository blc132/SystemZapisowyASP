﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SystemZapisowy.Repository.Interfaces;

namespace SystemZapisowy.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }


        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public IEnumerable<TEntity> GetOrdered<TKey>(Expression<Func<TEntity, TKey>> predicate, bool descending = false)
        {
            return descending ? Context.Set<TEntity>().OrderByDescending(predicate).ToList() : Context.Set<TEntity>().OrderBy(predicate).ToList();
        }

        public IEnumerable<TEntity> GetOrdered<TKey>(Expression<Func<TEntity, TKey>> predicate, Expression<Func<TEntity, TKey>> thenBy, bool firstDescending = false, bool secondDescending = false)
        {
            if (firstDescending && secondDescending)
                return Context.Set<TEntity>().OrderByDescending(predicate).ThenByDescending(thenBy).ToList();

            if (firstDescending && !secondDescending)
                return Context.Set<TEntity>().OrderByDescending(predicate).ThenBy(thenBy).ToList();

            if (!firstDescending && secondDescending)
                return Context.Set<TEntity>().OrderBy(predicate).ThenByDescending(thenBy).ToList();

            return Context.Set<TEntity>().OrderBy(predicate).ThenBy(thenBy).ToList();
        }
    }
}