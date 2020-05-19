using System.Collections.Generic;
using SongCollector.Models;

namespace SongCollector.Data
{
    public interface ISongCollectorRepo
    {
        IEnumerable<Song> GetSongs();
        Song GetSongById(int id);
    }
}