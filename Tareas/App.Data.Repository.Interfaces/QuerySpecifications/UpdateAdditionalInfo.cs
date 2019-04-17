using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interfaces.QuerySpecifications
{
    public class UpdateAdditionalInfo<TEntity>
    {
        public List<Expression<Func<TEntity, object>>> ExcludeFields
        { get; set; } = new List<Expression<Func<TEntity, object>>>();
    }
}
