using AutoMapper;
using SongCollector.Dtos;
using SongCollector.Models;

namespace SongCollector.Profiles
{
    public class SongsProfile : Profile
    {
        public SongsProfile()
        {
            CreateMap<Song, SongReadDto>();
        }
    }
}