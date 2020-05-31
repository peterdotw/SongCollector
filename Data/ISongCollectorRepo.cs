using System.Collections.Generic;
using SongCollector.Models;

namespace SongCollector.Data
{
    public interface ISongCollectorRepo
    {
        bool SaveChanges();

        IEnumerable<Song> GetAllSongs();
        Song GetSongById(int id);
        void CreateSong(Song sng);
        void UpdateSong(Song sng);
    }
}