using InAndOut.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Data
{
    public class ApplicationDBContext : DbContext  //inherited from db context class using entityframworkcore package

    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }//items is the table name


        public DbSet<Expense> expense { get; set; }

       


    }
}
