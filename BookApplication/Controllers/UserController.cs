using BookApplication.Core.Models;
using BookApplication.Core.Models.Dtos;
using BookApplication.Infrastructure.Context;
using BookApplication.Service.Implementations;
using BookApplication.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly BookDbContext _context;

        public UserController(BookDbContext dbContext, IBookService service)
        {
            _service = service;
            _context = dbContext;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            try
            {
                var user = await _context.AppUsers.FirstOrDefaultAsync(u => u.UserName == model.UserName);
                if (user == null)
                {
                    return Unauthorized("Invalid username or password");
                }

                if (model.Password == user.Password)
                {
                    return Unauthorized("Invalid username or password");
                }

                return Ok("Login successful");
            }
            catch (Exception )
            {
                throw;
            }
           
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDto model)
        {
            if (await _context.AppUsers.AnyAsync(u => u.UserName == model.UserName))
            {
                return BadRequest("Username already exists");
            }

            var user = new AppUser
            {
                UserName = model.UserName,
                Password = model.Password,
                Email = model.Email
            };

            _context.AppUsers.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Registration successful");

        }
        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteUserById(string Id)
        {
            var searchForUser = await _context.AppUsers.FindAsync(Id);
            if (searchForUser == null) return BadRequest("User not found");
            _context.AppUsers.Remove(searchForUser);
            await _context.SaveChangesAsync();
            return Ok("User's profile successfully deleted.");
        }
        [HttpGet("page")]
        public async Task<IActionResult> GetAllUser(int page, int perpage)
        {

            var books = await _service.GetAllProfiles(page, perpage);
            return Ok(books);
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetUserById(string Id)
        {
            var books = await _service.GetProfileById( Id);
            return Ok(books);
        }
        [HttpPut("Id")]
        public async Task<IActionResult> UpdateById(string Id, UserDto appUser)
        {
            var books = await _service.UpdateProfileById( Id, appUser );
             //books.SaveChangesAsync();
            return NoContent();
        }
    }
}
