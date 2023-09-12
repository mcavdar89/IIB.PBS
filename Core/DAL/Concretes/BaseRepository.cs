using AutoMapper;
using Core.DAL.Abstracts;
using Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DAL.Concretes
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly DbContext _contex;
        private readonly IMapper _mapper;
        public BaseRepository(DbContext context, IMapper mapper)
        {
            _contex = context;
            _mapper = mapper;
        }
        public IEnumerable<TEntity> List<TEntity>(Expression<Func<TEntity, bool>>? filter) where TEntity : BaseEntity, new()
        {
            if (filter == null)
            {
                return _contex.Set<TEntity>();
            }

            return _contex.Set<TEntity>().Where(filter);
        }
        public IEnumerable<TDto> ListProject<TEntity,TDto>(Expression<Func<TEntity, bool>>? filter) where TEntity : BaseEntity, new()
        {

            IQueryable<TEntity> query = _contex.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return _mapper.ProjectTo<TDto>(query);
        }
        public void Add<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            _contex.Set<TEntity>().Add(entity);

        }
        public void AddRange<TEntity>(TEntity[] entityList) where TEntity : BaseEntity, new()
        {
            _contex.Set<TEntity>().AddRange(entityList);

        }


        public void Update<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            var data = _contex.Set<TEntity>().SingleOrDefault(d => d.Id == entity.Id);

            if (data == null)
                return;


            _contex.Set<TEntity>().Update(entity);

        }

        public void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            var data = _contex.Set<TEntity>().SingleOrDefault(d => d.Id == entity.Id);

            if (data == null)
                return;


            _contex.Set<TEntity>().Remove(entity);

        }


        public void SaveAll()
        {
            _contex.SaveChanges();
        }



    }
}
