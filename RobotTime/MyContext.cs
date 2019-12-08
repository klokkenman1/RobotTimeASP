using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Exercise> Exercises { get; set; }

    }

    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MUrl { get; set; }
        public int Time { get; set; }
        public string FUrl { get; set; }
    }
}
