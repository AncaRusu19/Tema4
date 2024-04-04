using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IRepository<Author> _authorRepository;

        public AuthorController(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet("getall")]
        public IEnumerable<authorDto> GetAll()
        {
            return _authorRepository
                .GetAll()
                .Select(author => new authorDto(author.Name));
        }

        [HttpPost("add")]
        public IActionResult Post(authorDto authorDto)
        {
            if (authorDto == null || string.IsNullOrEmpty(authorDto.Name))
            {
                return BadRequest("Numele autorului este obligatoriu.");
            }

            var author = new Author()
            {
                Name = authorDto.Name,
            };

            _authorRepository.Add(author);
            _authorRepository.SaveChanges();

            return Ok("Autorul a fost adăugat cu succes.");
        }
        [HttpPut("update")]
        public ObjectResult Put(Guid authorId, authorDto author)
        {
            var authorFromDb = _authorRepository.GetById(authorId);

            if (authorFromDb == null)
            {
                return NotFound("Author not found");
            }

            authorFromDb.Name = author.Name;
           

            _authorRepository.SaveChanges();

            return Ok("Author updated succesfully");
        }
        [HttpDelete("delete")]
        public ObjectResult Delete(Guid authorId)
        {
            var authorFromDb = _authorRepository.GetById(authorId);

            if (authorFromDb == null)
            {
                return NotFound("Author not found");
            }

            _authorRepository.Remove(authorFromDb);
            _authorRepository.SaveChanges();

            return Ok("Removed succesfully");
        }
    }
}