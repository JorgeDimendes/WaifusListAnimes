using System.ComponentModel.DataAnnotations;

namespace WaifusListAnimes.Models
{
    public class Genero
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome Obrigatorio")]
        [StringLength(50)]
        public string Nome { get; set; }

        //public Guid AnimesId { get; set; }
        //public List<Anime>? Animes { get; set; } = new List<Anime>();

        public List<AnimeGenero>? AnimeGeneros { get; set; }

        // Gerar automaticamente o Id
        public Genero()
        {
            Id = Guid.NewGuid();
        }
    }
}
