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
    public class SystemMessageController : ControllerBase
    {
        private ISystemMessageRepository systemMessageRepository;

        public SystemMessageController(ISystemMessageRepository systemMessageRepository)
        {
            this.systemMessageRepository = systemMessageRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SystemMessage>> GetSystemMessageById(int id)
        {
            return await systemMessageRepository.GetSystemMessageById(id);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<SystemMessage>>> GetSystemMessagesByUser(int userId)
        {
            return await systemMessageRepository.GetSystemMessagesByUser(userId);
        }

        [HttpPost]
        public async Task AddSystemMessage(SystemMessage systemMessage)
        {
            await systemMessageRepository.AddSystemMessage(systemMessage);
            await systemMessageRepository.Save();
        }

        [HttpDelete("{id}")]
        public async Task DeleteSystemMessage(int id)
        {
            await systemMessageRepository.DeleteSystemMessage(id);
            await systemMessageRepository.Save();
        }
    }
}
