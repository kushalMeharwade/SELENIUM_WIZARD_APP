using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Wizard.Data
{   
    public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args=null)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>();
            options.UseSqlServer(@"Server=KUSHAL; Database=SeleniumWizard; Trusted_Connection=True");
            return new AppDbContext(options.Options);
        }
    }
}
