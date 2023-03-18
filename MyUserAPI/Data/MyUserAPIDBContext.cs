using Microsoft.EntityFrameworkCore;
using MyUserAPI.Models;

namespace MyUserAPI.Data
{
    public class MyUserAPIDBContext : DbContext
    {
        public MyUserAPIDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet <MyUser> Users { get; set; }   
    }
}
