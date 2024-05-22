using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Wizard.Data.Interfaces
{
    public interface IDataService<T>
    {

        Task<List<T>> GetAll();
        Task<T> Get(string id);

        Task<T> GetInt(int id);
        T GetIntNormal(int id);
        Task<T> Create(T entity);
        Task<bool> Delete(T entity);
        Task<T> Update(T entity);
        List<T> GetAllWithCondition(Expression<Func<T, bool>>? filter = null);


        Task<bool> Any(Expression<Func<T, bool>> filter);
        Task<int> Count(Expression<Func<T, bool>> filter = null);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> filter);
        Task<List<T>> GetRange(int skip, int take, Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetOrdered(Expression<Func<T, object>> orderBy, bool isDescending = false);

        int GetPrimaryKey();
    }
}
