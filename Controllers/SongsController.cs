using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SongCollector.Data;
using SongCollector.Dtos;
using SongCollector.Models;
using Microsoft.AspNetCore.Authorization;

namespace SongCollector.Controllers
{
    [ApiController]
    [Route("api/songs")]
    public class SongsController : ControllerBase
    {
        private readonly ISongCollectorRepo _repository;
        private readonly IMapper _mapper;

        public SongsController(ISongCollectorRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SongReadDto>> GetAllSongs()
        {
            var songItems = _repository.GetAllSongs();

            return Ok(_mapper.Map<IEnumerable<SongReadDto>>(songItems));
        }

        [HttpGet("{id}", Name = "GetSongById")]
        public ActionResult<SongReadDto> GetSongById(int id)
        {
            var songItem = _repository.GetSongById(id);

            if (songItem != null)
            {
                return Ok(_mapper.Map<SongReadDto>(songItem));
            }

            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public ActionResult<SongReadDto> CreateSong(SongCreateDto songCreateDto)
        {
            var songModel = _mapper.Map<Song>(songCreateDto);
            _repository.CreateSong(songModel);
            _repository.SaveChanges();

            var songReadDto = _mapper.Map<SongReadDto>(songModel);

            return CreatedAtRoute(nameof(GetSongById), new { Id = songReadDto.Id }, songReadDto);
        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult UpdateSong(int id, SongUpdateDto songUpdateDto)
        {
            var songModelFromRepo = _repository.GetSongById(id);

            if (songModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(songUpdateDto, songModelFromRepo);

            _repository.UpdateSong(songModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [Authorize]
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateSong(int id, JsonPatchDocument<SongUpdateDto> patchDoc)
        {
            var songModelFromRepo = _repository.GetSongById(id);

            if (songModelFromRepo == null)
            {
                return NotFound();
            }

            var songToPatch = _mapper.Map<SongUpdateDto>(songModelFromRepo);
            patchDoc.ApplyTo(songToPatch, ModelState);

            if (!TryValidateModel(songToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(songToPatch, songModelFromRepo);

            _repository.UpdateSong(songModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult DeleteSong(int id)
        {
            var songModelFromRepo = _repository.GetSongById(id);

            if (songModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteSong(songModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}