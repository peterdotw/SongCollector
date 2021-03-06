using System.ComponentModel.DataAnnotations;

namespace SongCollector.Dtos
{
    public class SongBaseDto
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public string Artist { get; set; }

        public int Year { get; set; }
    }
}