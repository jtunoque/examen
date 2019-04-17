using App.Data.Repository.Interfaces.QuerySpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity:class
    {
        void Add(TEntity entity);
        void Update(TEntity entity, UpdateAdditionalInfo<TEntity> updateInfo= null);
        void Remove(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TResult> GetAll<TResult>(
             GetAdditionalInfo<TEntity, TResult> additionalInfo = null);

        IEnumerable<TEntity> GetAll(
            GetAdditionalSimpleInfo<TEntity> additionalInfo = null);

        int Count();
    }
}
