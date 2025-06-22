using System.ComponentModel.DataAnnotations;

namespace WaifusListAnimes.Models
{
    public class AnimeGenero
    {
        [Key]
        public Guid Id { get; set; }   // ID único para facilitar manutenção

        public Guid AnimeId { get; set; }
        public Guid GeneroId { get; set; }

        public Anime? Anime { get; set; }
        public Genero? Genero { get; set; }

        public AnimeGenero()
        {
            Id = Guid.NewGuid();
        }
    }
}