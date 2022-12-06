using Microsoft.EntityFrameworkCore;
using StockCaseProject.Domain.Entities;
using StockCaseProject.Repository.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCaseProject.Repository
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base
           (options)
        {

        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("ConnectionStrings:SqlConStr");
        //        //optionsBuilder.UseSqlServer(@"Server=localhost;Database=StockCaseProjectDb;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //When calling migrations, it will start
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = "Data Source=localhost;Initial Catalog=StockCaseProjectDb2;Persist Security Info=True;User ID=sa;Password=test123;Encrypt=false";
                optionsBuilder.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                }
                );
            }
        }
        //Stocks
        public DbSet<Stock> Stocks{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new StockSeed(new int[] { 1, 2, 3,4 }));



        }

    }
}
