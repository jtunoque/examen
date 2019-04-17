using App.Data.Repository.Interfaces;
using App.Data.Repository.Interfaces.QuerySpecifications;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class GenericRepository<TEntity> :
        IGenericRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext context;

        public GenericRepository(DbContext pContext)
        {
            this.context = pContext;
        }

        public void Add(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
        }

        public int Count()
        {
            return this.context.Set<TEntity>().Count();
        }

        /// <summary>
        /// Metodo para obtener una lista de datos por filtros
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes">
        /// El include, incluye las tablas que estan relacionada a 
        /// la tabla principal, ejemplo "Marca,Categoria,UnidadMedida"
        /// </param>
        /// <returns></returns>
        public IEnumerable<TResult> GetAll<TResult>(
            GetAdditionalInfo<TEntity,TResult> additionalInfo= null)
        {
            var result = new List<TResult>();
            IQueryable<TEntity> query = this.context.Set<TEntity>();
           
            if (additionalInfo != null)
            {
                //Inludes
                if (additionalInfo.IncludeFields != null)
                {
                    foreach (var tableInclude in additionalInfo.IncludeFields)
                    {
                        query = query.Include(tableInclude);
                    }
                }

                //Where
                if (additionalInfo.Filters != null)
                {
                    query = query.Where(additionalInfo.Filters);
                }

                if (additionalInfo.OrderBy !=null)
                {
                    query =  additionalInfo.OrderBy(query);
                }

                if(additionalInfo.SelectFields!=null)
                {
                    result = query.Select<TEntity,TResult>(additionalInfo.SelectFields).ToList();
                }
            }

            return result;
        }

        public IEnumerable<TEntity> GetAll(
            GetAdditionalSimpleInfo<TEntity> additionalInfo = null)
        {

            return GetAll<TEntity>(
                    new GetAdditionalInfo<TEntity, TEntity>()
                    {
                        IncludeFields=additionalInfo?.IncludeFields,
                        OrderBy=additionalInfo?.OrderBy,
                        Filters=additionalInfo?.Filters,
                        SelectFields=item=>item
                    }
                );

           
        }




            public TEntity GetById(int id)
        {
            return this.context.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            this.context.Set<TEntity>().Attach(entity);
            this.context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity, UpdateAdditionalInfo<TEntity> updateInfo = null)
        {
            this.context.Set<TEntity>().Attach(entity);
            this.context.Entry<TEntity>(entity).State = EntityState.Modified;

            foreach(var fieldExluded in  updateInfo.ExcludeFields)
            {
                this.context.Entry<TEntity>(entity).Property(fieldExluded).IsModified=false;
            }
            
        }
    }
}
