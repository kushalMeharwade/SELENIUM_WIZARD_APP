using Microsoft.EntityFrameworkCore;
using Selenium_Wizard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Selenium_Wizard.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Automation_Names> Automation_Names { get; set; }

        public DbSet<Automation_Types> Automation_Types { get; set; }

        public DbSet<Element_Item> WebElements { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {


        }

        public AppDbContext()
        {
          
        }
    }
}
