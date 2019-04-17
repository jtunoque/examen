using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace App.Data.Repository.Interfaces.QuerySpecifications
{
    public class GetAdditionalInfo<TEntity,TResult>
    {
        public Expression<Func<TEntity,TResult>> SelectFields{ get; set; } = null;
        public Expression<Func<TEntity, bool>> Filters { get; set; } = null;
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy { get; set; } = null;
        public List<Expression<Func<TEntity, object>>> IncludeFields
        { get; set; } = new List<Expression<Func<TEntity, object>>>();
    }
}