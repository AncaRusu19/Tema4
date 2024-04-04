using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrackController : ControllerBase
    {
        private readonly IRepository<Track> _trackRepository;

        public TrackController(IRepository<Track> trackRepository)
        {
            _trackRepository = trackRepository;
        }

        [HttpGet("getall")]
        public IEnumerable<trackDto> GetAll()
        {
            return _trackRepository
                .GetAll()
                .Select(track => new trackDto(track.Title_track));
        }

        [HttpPost("add")]
        public IActionResult Post(trackDto trackDto)
        {
            if (trackDto == null || string.IsNullOrEmpty(trackDto.Title_track))
            {
                return BadRequest("Titlul piesei este obligatoriu.");
            }

            var track = new Track()
            {
                Title_track = trackDto.Title_track,
            };

            _trackRepository.Add(track);
            _trackRepository.SaveChanges();

            return Ok("Piesa a fost adăugată cu succes.");
        }
        [HttpPut("update")]
        public ObjectResult Put(Guid trackId, trackDto track)
        {
            var trackFromDb = _trackRepository.GetById(trackId);

            if (trackFromDb == null)
            {
                return NotFound("Track not found");
            }

            trackFromDb.Title_track = track.Title_track;


            _trackRepository.SaveChanges();

            return Ok("Track updated succesfully");
        }
        [HttpDelete("delete")]
        public ObjectResult Delete(Guid trackId)
        {
            var trackFromDb = _trackRepository.GetById(trackId);

            if (trackFromDb == null)
            {
                return NotFound("Track not found");
            }

            _trackRepository.Remove(trackFromDb);
            _trackRepository.SaveChanges();

            return Ok("Removed succesfully");
        }
    }
}