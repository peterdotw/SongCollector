using System.Collections.Generic;
using SongCollector.Models;

namespace SongCollector.Data
{
    public class MockSongCollectorRepo : ISongCollectorRepo
    {
        public void CreateSong(Song sng)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Song> GetAllSongs()
        {
            var songs = new List<Song>
            {
                new Song { Id = 1, Name = "Oblivion", Artist = "Grimes", Year = 2012 },
                new Song { Id = 2, Name = "Too Late", Artist = "Washed Out", Year = 2020 },
                new Song { Id = 3, Name = "They're Back", Artist = "Yuzo Koshiro", Year = 2020 }
            };

            return songs;
        }

        public Song GetSongById(int id)
        {
            return new Song { Id = 1, Name = "Oblivion", Artist = "Grimes", Year = 2012 };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateSong(Song sng)
        {
            throw new System.NotImplementedException();
        }
    }
}