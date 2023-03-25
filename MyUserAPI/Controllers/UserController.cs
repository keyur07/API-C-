using System;
using Microsoft.AspNetCore.Mvc;
using MyUserAPI.Data;
using MyUserAPI.Models;

namespace MyUserAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext context;

        public UsersController(DatabaseContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<userModel> Get()
        {
            return context.Users;
        }

        [HttpGet("{userid}")]
        public userModel Get(int Id)
        {
            try
            {
                return context.Users.Find(Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        public userModel Post([FromBody] userModel users)
        {
            context.Users.Add(users);
            context.SaveChanges();
            return users;
        }

        [HttpDelete("{userid}")]
        public void Delete(int Id)
        {
            var user = context.Users.Find(Id);
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}

