using AutoMapper;
using Core.DAL.Abstracts;
using Core.Model.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace Core.DAL.Concretes
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly DbContext _contex;
        private readonly IMapper _mapper;
        protected string _conStr;
        public BaseRepository(DbContext context, IMapper mapper)
        {
            _contex = context;
            _mapper = mapper;
        }
        
        public TEntity Get<TEntity>(Expression<Func<TEntity, bool>>? filter) where TEntity : BaseEntity, new()
        {
            return _contex.Set<TEntity>().SingleOrDefault(filter);         
        }
        public TDto GetProject<TEntity, TDto>(Expression<Func<TEntity, bool>>? filter) where TEntity : BaseEntity, new()
        {

            IQueryable<TEntity> query = _contex.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return _mapper.ProjectTo<TDto>(query).FirstOrDefault();
        }

        public IEnumerable<TEntity> List<TEntity>(Expression<Func<TEntity, bool>>? filter) where TEntity : BaseEntity, new()
        {
            if (filter == null)
            {
                return _contex.Set<TEntity>();
            }

            return _contex.Set<TEntity>().Where(filter);
        }
        public IEnumerable<TDto> ListProject<TEntity, TDto>(Expression<Func<TEntity, bool>>? filter) where TEntity : BaseEntity, new()
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


        public List<T> ListFromSql<T>(string sql)
        {
            var list = new List<T>();

            using (SqlConnection con = new SqlConnection(_conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {

                    try
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();

                        DataTable dt = new DataTable();
                        //dt.Load(cmd.ExecuteReader());
                        //using (SqlDataReader reader = cmd.ExecuteReader())
                        //{
                        //    dt.Load(reader);
                        //}
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        list = DataTableMapToList<T>(dt);

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }


                }

            }


            return list;

        }

        public List<T> DataTableMapToList<T>(DataTable dt)
        {
            var list = new List<T>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(GetItem<T>(dt.Rows[i]));
            }
            return list;
        }

        public T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                foreach (PropertyInfo prop in temp.GetProperties())
                {
                    try
                    {
                        if (prop.Name == dr.Table.Columns[i].ColumnName && !object.Equals(dr[dr.Table.Columns[i].ColumnName], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[dr.Table.Columns[i].ColumnName], null);
                        }
                        else
                            continue;


                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

            }

            return obj;
        }


    }
}
