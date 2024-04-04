using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IRepository<User> _userRepository;


        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet("get")]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetAll();
        }

        [HttpPost("add")]
        public ObjectResult Add(UserDto userDto)
        {
            _userRepository.Add(new User(userDto.Name, userDto.Email, userDto.Password, userDto.TypeId));
            _userRepository.SaveChanges();

            return Ok("Added successfully.");
        }

        [HttpPut("update")]
        public ObjectResult Update(Guid id, UserDto userDto)
        {
            throw new NotImplementedException();
        }



        [HttpPut("delete")]
        public ObjectResult Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
