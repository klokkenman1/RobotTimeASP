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
            modelBuilder.Entity<Exercise>().HasData(new Exercise {Id = 1, Name = "Exercise 1", Time = 5, Url = "https://cdn.discordapp.com/attachments/639062904020140034/641286527581683772/Standje_2.png" });
            modelBuilder.Entity<Exercise>().HasData(new Exercise {Id = 2, Name = "Exercise 2", Time = 5, Url = "https://cdn.discordapp.com/attachments/639062904020140034/641286530186608644/Movement_1.png" });
        }

        public DbSet<Exercise> Exercises { get; set; }

    }

    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Time { get; set; }
    }
}
