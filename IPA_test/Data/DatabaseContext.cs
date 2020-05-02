using IPA_test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPA_test.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Image> Images { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlite("Data Source=DB.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rent>().ToTable("Rent");
            modelBuilder.Entity<House>().ToTable("House");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Image>().ToTable("Image");
        }
    }
}
