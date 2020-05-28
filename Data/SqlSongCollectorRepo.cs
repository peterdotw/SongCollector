using System;
using System.Collections.Generic;
using System.Linq;
using SongCollector.Models;

namespace SongCollector.Data
{
    public class SqlSongCollectorRepo : ISongCollectorRepo
    {
        private readonly SongCollectorContext _context;

        public SqlSongCollectorRepo(SongCollectorContext context)
        {
            _context = context;
        }

        public void CreateSong(Song sng)
        {
            if (sng == null)
            {
                throw new ArgumentNullException(nameof(sng));
            }

            _context.Songs.Add(sng);
        }

        public IEnumerable<Song> GetAllSongs()
        {
            return _context.Songs.ToList();
        }

        public Song GetSongById(int id)
        {
            return _context.Songs.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}