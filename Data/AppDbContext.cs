using Microsoft.EntityFrameworkCore;
using PaginationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginationDemo.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
