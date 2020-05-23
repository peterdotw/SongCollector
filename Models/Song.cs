using System.ComponentModel.DataAnnotations;

namespace SongCollector.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public string Artist { get; set; }

        public int Year { get; set; }
    }
}