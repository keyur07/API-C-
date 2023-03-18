using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyUserAPI.Data;
using MyUserAPI.Models;

namespace MyUserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyUserController: Controller
    {
        private readonly MyUserAPIDBContext dbContext;

        public MyUserController(MyUserAPIDBContext dbContext )
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetMyUsers()
        {
            return Ok(dbContext.Users.ToList());
        }

        [HttpGet]
        [Route("{Id:guid}")]
        public IActionResult GetMyUser([FromRoute] Guid Id)
        {
            var user = dbContext.Users.Find(Id);
            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddMyUsers(AddMyUser myUser2bAdded)
        {
            var user = new MyUser()
            {
                Id = Guid.NewGuid(),
                Name = myUser2bAdded.Name,
                Email = myUser2bAdded.Email,
                status = myUser2bAdded.status
            };

            // For async method use await
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut]
        [Route("{Id:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid Id, UpdateMyUser updateMyUser)
        {
            var user = dbContext.Users.Find(Id);
            if (user != null)
            {
                user.Id = updateMyUser.Id;
                user.Name = updateMyUser.Name;
                user.Email = updateMyUser.Email;
                user.status = updateMyUser.status;

                // For async method use await
                await dbContext.SaveChangesAsync();

                return Ok(user);
                //
            }

            return NotFound();
        }
    }
}

