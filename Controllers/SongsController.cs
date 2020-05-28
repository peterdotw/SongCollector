using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SongCollector.Data;
using SongCollector.Dtos;
using SongCollector.Models;

namespace SongCollector.Controllers
{
    [Route("api/songs")]
    [ApiController]
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

        [HttpPost]
        public ActionResult<SongReadDto> CreateSong(SongCreateDto songCreateDto)
        {
            var songModel = _mapper.Map<Song>(songCreateDto);
            _repository.CreateSong(songModel);
            _repository.SaveChanges();

            var songReadDto = _mapper.Map<SongReadDto>(songModel);

            return CreatedAtRoute(nameof(GetSongById), new { Id = songReadDto.Id }, songReadDto);
        }
    }
}