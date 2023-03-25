using System;
using Microsoft.EntityFrameworkCore;
using MyUserAPI.Models;

namespace MyUserAPI.Data
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
		}

        public DbSet<userModel> Users { get; set; }
        public DbSet<orderModel> Order { get; set; }
        public DbSet<productModel> Products { get; set; }
        public DbSet<cartModel> Cart { get; set; }
        public DbSet<commentModel> Comments { get; set; }
    }
}

