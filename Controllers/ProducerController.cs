using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducerController : ControllerBase
    {
        private readonly IRepository<Producer> _producerRepository;

        public ProducerController(IRepository<Producer> producerRepository)
        {
            _producerRepository = producerRepository;
        }

        [HttpGet("getall")]
        public IEnumerable<producerDto> GetAll()
        {
            return _producerRepository
                .GetAll()
                .Select(producer => new producerDto(producer.ProducerName));
        }
        [HttpPost("add")]
        public IActionResult Post(producerDto producerDto)
        {
            if (producerDto == null || string.IsNullOrEmpty(producerDto.ProducerName))
            {
                return BadRequest("Numele producătorului este obligatoriu.");
            }

            var producer = new Producer()
            {
                ProducerName = producerDto.ProducerName,
            };

            _producerRepository.Add(producer);
            _producerRepository.SaveChanges();

            return Ok("Producătorul a fost adăugat cu succes.");
        }
        [HttpPut("update")]
        public ObjectResult Put(Guid producerId, producerDto producer)
        {
            var producerFromDb = _producerRepository.GetById(producerId);

            if (producerFromDb == null)
            {
                return NotFound("Producer not found");
            }

            producerFromDb.ProducerName = producer.ProducerName;


            _producerRepository.SaveChanges();

            return Ok("Producer updated succesfully");
        }
        [HttpDelete("delete")]
        public ObjectResult Delete(Guid producerId)
        {
            var producerFromDb = _producerRepository.GetById(producerId);

            if (producerFromDb == null)
            {
                return NotFound("Producer not found");
            }

            _producerRepository.Remove(producerFromDb);
            _producerRepository.SaveChanges();

            return Ok("Removed succesfully");
        }
    }
}