using System.Collections.Generic;
using SongCollector.Models;

namespace SongCollector.Data
{
    public class MockSongCollectorRepo : ISongCollectorRepo
    {
        public IEnumerable<Song> GetSongs()
        {
            var songs = new List<Song>
            {
                new Song { Id = 0, Name = "Oblivion", Artist = "Grimes", Year = 2012 },
                new Song { Id = 1, Name = "Too Late", Artist = "Washed Out", Year = 2020 },
                new Song { Id = 2, Name = "Oblivion", Artist = "Grimes", Year = 2012 }
            };

            return songs;
        }

        public Song GetSongById(int id)
        {
            return new Song { Id = 0, Name = "Oblivion", Artist = "Grimes", Year = 2012 };
        }
    }
}