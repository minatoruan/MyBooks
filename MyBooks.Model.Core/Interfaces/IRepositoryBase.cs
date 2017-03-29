using System;
using System.Collections.Generic;
using MyBooks.Model.Entities;

namespace MyBooks.Model.Core.Interfaces
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        void InsertOneAsync(T entity);

        IList<T> GetList();

        T GetByIdAsyn(Guid id);

        bool Exists(Guid id);
    }
}