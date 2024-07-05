using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHouse.Server.Entity;
using SmartHouse.Server.Model_DTO.User_DTO;

namespace SmartHouse.Server.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DBContext dbContext;

        public UserController(DBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet("get_list")]
        public async Task<IActionResult> GetList()
        {
            var users = await dbContext.TbUsers.ToListAsync();
            return Ok(users);
        }
        [HttpPost("post")]
        public async Task<bool> Post(CreateUserRequest obj)
        {
            TbUser user = new TbUser();
            user.Id = Guid.NewGuid();
            user.UserName = obj.UserName;
            user.Email = obj.Email;
            user.Password = obj.Password;
            user.Position = obj.Position;
            user.UserCode = obj.UserCode;
            user.FullName = obj.FullName;
            user.InActive = obj.InActive;
            user.UpdateDate = DateTime.Now;
            user.CreateDate = DateTime.Now;
            if (user != null)
            {
                try
            {
                
                   await dbContext.TbUsers.AddAsync(user);
                    await dbContext.SaveChangesAsync();
                    return true;
                
               
            }
            catch (Exception e)
            {
                Console.WriteLine( e.Message);
            }
            }
            return false;
        }
        [HttpPut("put/{id}")]
        public async Task<bool> Put( Guid id, CreateUserRequest obj)
        {
            TbUser tbUser = dbContext.TbUsers.ToList().SingleOrDefault(c => c.Id == id);
            tbUser.Email = obj.Email;
            tbUser.Password = obj.Password;
            tbUser.Position = obj.Position;
            tbUser.FullName = obj.FullName;
            tbUser.InActive = obj.InActive;
            if(tbUser != null)
            {
                
                try
                {
                    dbContext.TbUsers.Update(tbUser);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }
        [HttpDelete("delete/{id}")]
        public async Task<bool> Remove(Guid id)
        {
            TbUser tbUser = dbContext.TbUsers.ToList().SingleOrDefault(c => c.Id == id);
            if (tbUser != null)
            {
                try
                {
                    dbContext.TbUsers.Remove(tbUser);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }
    }
}
