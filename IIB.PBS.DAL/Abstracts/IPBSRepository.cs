using IIB.PBS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.DAL.Abstracts
{
    public interface IPBSRepository
    {
        IEnumerable<TEntity> List<TEntity>(Expression<Func<TEntity, bool>>? filter) where TEntity : BaseEntity, new();

        void Add<TEntity>(TEntity entity) where TEntity : BaseEntity, new();
        void SaveAll();
    }
}
