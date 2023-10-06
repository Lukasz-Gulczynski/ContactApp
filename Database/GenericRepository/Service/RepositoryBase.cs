﻿using ContactsApp.Repo.Data;
using ContactsApp.Repo.GenericRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ContactsApp.Repo.GenericRepository.Service
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext) =>
            RepositoryContext = repositoryContext;

        public async Task<IQueryable<T>> FindAllAsync(bool trackChanges)
        {
            return !trackChanges ? await Task.Run(() => RepositoryContext.Set<T>().AsNoTracking()) : await Task.Run(() => RepositoryContext.Set<T>());
        }

        public async Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? await Task.Run(() => RepositoryContext.Set<T>().Where(expression).AsNoTracking()) : await Task.Run(() => RepositoryContext.Set<T>().Where(expression));
        }

        public async Task CreateAsync(T entity)
        {
            await Task.Run(() => RepositoryContext.Set<T>().Add(entity));
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => RepositoryContext.Set<T>().Update(entity));
        }

        public async Task RemoveAsync(T entity)
        {
            await Task.Run(() => RepositoryContext.Set<T>().Remove(entity));
        }
    }
}
