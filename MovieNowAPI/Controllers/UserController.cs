using System;
using System.Net;
using MovieNowAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieNowAPI.Repository;

namespace MovieNowAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            return await userRepository.GetUserById(id);
        }

        [HttpGet("username/{username}")]
        public async Task<ActionResult<User>> GetUserByUsername(string username)
        {
            return await userRepository.GetUserByUsername(username);
        }

        [HttpPost]
        public async Task AddUser(User user)
        {
            await userRepository.AddUser(user);
            await userRepository.Save();
        }

        [HttpPut]
        public async Task UpdateUser(User user)
        {
            await userRepository.UpdateUser(user);
            await userRepository.Save();
        }

        [HttpDelete("{id}")]
        public async Task DeleteUser(int id)
        {
            await userRepository.DeleteUser(id);
            await userRepository.Save();
        }
        

    }
}