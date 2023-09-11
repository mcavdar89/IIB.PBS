using IIB.PBS.DAL.Abstracts;
using IIB.PBS.DAL.Contexts;
using IIB.PBS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.DAL.Concretes
{
    public class PBSRepository : IPBSRepository
    {
        private readonly PBSContext _contex;
        public PBSRepository(PBSContext context)
        {
                _contex = context;
        }
        public IEnumerable<TEntity> List<TEntity>(Expression<Func<TEntity, bool>>? filter) where TEntity : BaseEntity , new()
        {
            if(filter == null)
            {
                return _contex.Set<TEntity>();
            }

            return _contex.Set<TEntity>().Where(filter);
        }

        public void Add<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            _contex.Set<TEntity>().Add(entity);
            
        }
        public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            var data =_contex.Set<TEntity>().SingleOrDefault(d => d.Id == entity.Id);

            if (data == null)
                return;


            _contex.Set<TEntity>().Update(entity);

        }

        public void SaveAll()
        {
            _contex.SaveChanges();
        }



    }
}
