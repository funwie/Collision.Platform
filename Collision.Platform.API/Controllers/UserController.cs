using Collision.Platform.Domain;
using Collision.Platform.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Collision.Platform.API.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepository.All();
        }


        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userRepository.Get(id);
        }


        [HttpPost]
        public User Post([FromBody] User user)
        {
            return _userRepository.Add(user);
        }


        [HttpPut("{id}")]
        public User Put(int id, [FromBody] User user)
        {
            return _userRepository.Update(user);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
