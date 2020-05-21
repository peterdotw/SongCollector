using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SongCollector.Data;
using SongCollector.Models;

namespace SongCollector.Controllers
{
    [Route("api/songs")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongCollectorRepo _repository;

        public SongsController(ISongCollectorRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Song>> GetAllSongs()
        {
            var songItems = _repository.GetSongs();

            return Ok(songItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Song> GetSongById(int id)
        {
            var songItem = _repository.GetSongById(id);

            return Ok(songItem);
        }
    }
}