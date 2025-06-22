using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaifusListAnimes.Data;
using WaifusListAnimes.Models;

namespace WaifusListAnimes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnimeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimes()
        {
            try
            {
                var reslt = await _context.Anime.ToListAsync();
                return Ok(reslt);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na listagem de animes - {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAnime(Anime anime)
        {
            try
            {
                await _context.Anime.AddAsync(anime);
                var valor = await _context.SaveChangesAsync();
                if(valor == 1)
                {
                    return Ok("Sucesso, anime cadastrado");
                }
                else
                {
                    return BadRequest("Erro, anime não cadastrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro no cadastro de animes - {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAnime(Anime anime)
        {
            try
            {
                _context.Anime.Update(anime);
                var valor = await _context.SaveChangesAsync();
                if (valor == 1)
                {
                    return Ok("Sucesso, anime atualizado");
                }
                else
                {
                    return BadRequest("Erro, anime não atualizado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na atualização de animes - {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnime([FromRoute] Guid id)
        {
            try
            {
                Anime anime = await _context.Anime.FindAsync(id);

                if(anime != null)
                {
                    _context.Anime.Remove(anime);
                    var valor = await _context.SaveChangesAsync();
                    if( valor == 1)
                    {
                        return Ok("Sucesso na exclusão");
                    }
                    else
                    {
                        return BadRequest("Erro, estado não excluido");
                    }
                }
                else
                {
                    return BadRequest("Erro, anime não existe");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na exclusão de anime - {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnime([FromRoute] Guid id)
        {
            try
            {
                Anime anime = await _context.Anime.FindAsync(id);

                if (anime != null)
                {
                    return Ok(anime);
                }
                else
                {
                    return BadRequest("Erro, anime não existe");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na listagem de anime - {ex.Message}");
            }
        }

        [HttpGet("Pesquisar")]
        public async Task<IActionResult> GetAnimePesquisa([FromQuery] string valor)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(valor))
                    return BadRequest("Informe um valor para pesquisar.");

                valor = valor.Trim().ToUpper();

                var animes = await _context.Anime
                    .Include(a => a.AnimeGeneros)  // carrega os relacionamentos
                        .ThenInclude(ag => ag.Genero)  // entra no gênero
                    .Where(a =>
                        a.Titulo.ToUpper().Contains(valor) ||
                        a.AnimeGeneros.Any(ag => ag.Genero != null && ag.Genero.Nome.ToUpper().Contains(valor))
                    )
                    .ToListAsync();

                if( animes != null || animes.Count == 0)
                {
                    return NotFound($"Nenhum anime encontrado com o termo: {valor}");
                }

                return Ok(animes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na pesquisa de anime: - {ex.Message}");
            }
        }

    }
}
