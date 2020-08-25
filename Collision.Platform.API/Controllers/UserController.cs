using Collision.Platform.Domain;
using Collision.Platform.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Collision.Platform.API.Controllers
{
    [Route("users")]
    [ApiController]
    [Produces("application/json")] 
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IEnumerable<User> Get()
        {
            return _userRepository.All();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult<User> Get(int id)
        {
            var user = _userRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            
            return user;
        }


        [HttpPost]
        [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<User> Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Username");
            }

            if(_userRepository.All().Any(u => u.Username == user.Username))
            {
                return BadRequest("Username already taken, try another one");
            }
            var addedUser = _userRepository.Update(user);
            _userRepository.SaveChanges();

            return addedUser;
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid User");
            }

            if (_userRepository.All().Any(u => u.Username == user.Username && u.Id != id))
            {
                return BadRequest("Username already taken, try another one");
            }

            var existingUser = _userRepository.Get(id);
            existingUser.Username = user.Username;
            _userRepository.Update(existingUser);
            _userRepository.SaveChanges();

            return existingUser;
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        public void Delete(int id)
        {

            _userRepository.Delete(id);
            _userRepository.SaveChanges();
        }
    }
}
