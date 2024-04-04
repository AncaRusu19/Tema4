using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserTypeController : ControllerBase
    {

        private readonly IRepository<UserType> _userTypeRepository;


        public UserTypeController(IRepository<UserType> userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }


        [HttpGet("get")]
        public IEnumerable<UserType> Get()
        {
            return _userTypeRepository.GetAll();
        }

        [HttpPost("add")]
        public ObjectResult Add(UserTypeDto userTypeDto)
        {
            _userTypeRepository.Add(new UserType(userTypeDto.Name));
            _userTypeRepository.SaveChanges();

            return Ok("Updated successfully.");
        }

        [HttpPut("update")]
        public ObjectResult Update(Guid id, UserTypeDto userTypeDto)
        {
            throw new NotImplementedException();
        }



        [HttpPut("delete")]
        public ObjectResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}
