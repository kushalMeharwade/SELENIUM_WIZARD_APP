using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Selenium_Wizard.Data.Interfaces;

namespace Selenium_Wizard.Data
{
    public class GenericDataService<T> : IDataService<T> where T : class
    {

        private readonly DbContextFactory _contextFactory;
        private readonly NonQueryDataService<T> _NonGenericDataService;

        private readonly AppDbContext _appDbContext;
        public GenericDataService(DbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _NonGenericDataService = new NonQueryDataService<T>(_contextFactory);
            _appDbContext = _contextFactory.CreateDbContext();
        }


        public async Task<T> Create(T entity)
        {
            return await _NonGenericDataService.Create(entity);
        }

        public async Task<bool> Delete(T entity)
        {
            return await (_NonGenericDataService.Delete(entity));
        }

        public async Task<T?> Get(string id)
        {
          
            return await _appDbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetInt(int id)
        {

            return await _appDbContext.Set<T>().FindAsync(id);
        }

        public  T GetIntNormal(int id)
        {

            return  _appDbContext.Set<T>().Find(id);
        }


        public int GetPrimaryKey()
        {
           
            var count =  _appDbContext.Set<T>().Count();
            int countA = Convert.ToInt32(count);
           

            countA++;
            return countA;
        }

        public async Task<List<T>> GetAll()
        {
         
            return await _appDbContext.Set<T>().ToListAsync();
        }

        public List<T> GetAllNormal()
        {
           
            return _appDbContext.Set<T>().ToList();

        }

        public async Task<T> Update(T entity)
        {
            return await (_NonGenericDataService.Update(entity));
        }

        public  List<T> GetAllWithCondition(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _appDbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return  query.ToList();
        }


        public async Task<bool> Any(Expression<Func<T, bool>> filter)
        {
            return await _appDbContext.Set<T>().AnyAsync(filter);
        }

        public async Task<int> Count(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _appDbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.CountAsync();
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return await _appDbContext.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<List<T>> GetRange(int skip, int take, Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _appDbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<List<T>> GetOrdered(Expression<Func<T, object>> orderBy, bool isDescending = false)
        {
            IQueryable<T> query = _appDbContext.Set<T>();

            if (isDescending)
            {
                query = query.OrderByDescending(orderBy);
            }
            else
            {
                query = query.OrderBy(orderBy);
            }

            return await query.ToListAsync();
        }

        #region testing



        #endregion
    }
}
