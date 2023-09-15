
using Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL.Abstracts
{
    public interface IBaseRepository
    {
        TEntity Get<TEntity>(Expression<Func<TEntity, bool>>? filter) where TEntity : BaseEntity, new();

       IEnumerable<TEntity> List<TEntity>(Expression<Func<TEntity, bool>>? filter) where TEntity : BaseEntity, new();

        IEnumerable<TDto> ListProject<TEntity, TDto>(Expression<Func<TEntity, bool>>? filter) where TEntity : BaseEntity, new();

        List<T> ListFromSql<T>(string sql);

       void Add<TEntity>(TEntity entity) where TEntity : BaseEntity, new();
        void Update<TEntity>(TEntity entity) where TEntity : BaseEntity, new();
        void SaveAll();
    }
}
