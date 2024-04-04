using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VinylsController : ControllerBase
    {
        private readonly IRepository<Vinyl> _vinylRepository;

        public VinylsController(IRepository<Vinyl> vinylRepository)
        {
            _vinylRepository = vinylRepository;
        }

        [HttpGet("getall")]
        public IEnumerable<vinylDto> GetAll()
        {
            return _vinylRepository
                .GetAll()
                .Select(vinyl => new vinylDto(vinyl.Title, vinyl.Singer,vinyl.Age, vinyl.Best_Song));
        }

        [HttpPost("add")]
        public IActionResult Post(vinylDto vinylDto)
        {
            if (vinylDto == null || string.IsNullOrEmpty(vinylDto.Title) || string.IsNullOrEmpty(vinylDto.Singer))
            {
                return BadRequest("Titlul și cântărețul sunt obligatorii.");
            }

            if (vinylDto.Age < 0)
            {
                return BadRequest("Vârsta trebuie să fie mai mare sau egală cu zero.");
            }

            var vinyl = new Vinyl()
            {
                Title = vinylDto.Title,
                Singer = vinylDto.Singer,
                Age = vinylDto.Age,
                Best_Song = vinylDto.Best_Song
            };

            _vinylRepository.Add(vinyl);
            _vinylRepository.SaveChanges();

            return Ok("Vinilul a fost adăugat cu succes.");
        }
        [HttpPut("update")]
        public ObjectResult Put(Guid vinylId, vinylDto vinyl)
        {
            var vinylFromDb = _vinylRepository.GetById(vinylId);

            if (vinylFromDb == null)
            {
                return NotFound("Vinyl not found");
            }

            vinylFromDb.Title = vinyl.Title;
            vinylFromDb.Singer = vinyl.Singer;
            vinylFromDb.Age = vinyl.Age;
            vinylFromDb.Best_Song = vinyl.Best_Song;

            _vinylRepository.SaveChanges();

            return Ok("Vinyl updated succesfully");
        }
        [HttpDelete("delete")]
        public ObjectResult Delete(Guid vinylId)
        {
            var vinylFromDb = _vinylRepository.GetById(vinylId);

            if (vinylFromDb == null)
            {
                return NotFound("Vinyl not found");
            }

            _vinylRepository.Remove(vinylFromDb);
            _vinylRepository.SaveChanges();

            return Ok("Removed succesfully");
        }
    }
}