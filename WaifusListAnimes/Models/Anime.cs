using System.ComponentModel.DataAnnotations;

namespace WaifusListAnimes.Models
{
    public class Anime
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatorio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Descrição obrigatorio")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Status obrigatorio")]
        public string Status { get; set; }

        public int? AnoLancamento { get; set; }
        public string? UrlCapa { get; set; }
        public string? LinkAssistir { get; set; }
        public string? Episodios { get; set; }
        public string? Temporadas { get; set; }

        //public Genero Generos { get; set; } // Isso so permite adicionar 1 genero
        //public List<Genero>? Generos { get; set; } = new List<Genero>();

        public List<AnimeGenero>? AnimeGeneros { get; set; }

        // Gerar automaticamente o Id
        public Anime()
        {
            Id = Guid.NewGuid();
        }
    }
}