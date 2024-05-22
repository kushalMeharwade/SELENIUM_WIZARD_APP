using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Wizard.Data
{
    public  class NonQueryDataService<T> where T : class
    {
       

            private readonly DbContextFactory _contextFactory;
            private readonly NonQueryDataService<T> _nonQueryDataService;
            private readonly AppDbContext _appDbContext;

            public NonQueryDataService(DbContextFactory contextFactory)
            {
                _contextFactory = contextFactory;
            _appDbContext = _contextFactory.CreateDbContext();

            }

            public async Task<T> Create(T entiity)
            {
               
                EntityEntry createdResult = await _appDbContext.Set<T>().AddAsync(entiity);
                await _appDbContext.SaveChangesAsync();
                return  (T)createdResult.Entity;
            }


            public async Task<bool> Delete(T entity)
            {

            _appDbContext.Set<T>().Remove(entity);
                await _appDbContext.SaveChangesAsync();
                return true;
            }

            public async Task<T> Update(T entity)
            {
             
                EntityEntry<T> created_Result = _appDbContext.Set<T>().Update(entity);
                await _appDbContext.SaveChangesAsync();
                return created_Result.Entity;
            }


        
    }
}
