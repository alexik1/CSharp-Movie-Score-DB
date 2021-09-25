using FilmesAPI.EntityFrameworkCore;
using FilmesAPI.Filmes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
    public class RelacionalController : ControllerBase
    {
        public readonly FilmesAPIDbContext _context;

        public RelacionalController(FilmesAPIDbContext context)
        {
            _context = context;
        }

        // GET: /api/filmeId
        //Lista o nome dos espectadores que assistiram a um filme
        [HttpGet("listaEspectadorPorFilme/{filmeId}")]
        public ActionResult GetFilme(int filmeId)

        {
            try
            {
                var filmeEspectadorLista = _context.Filmes_Espectadores
                                   .Where(h => h.FilmeId == filmeId)
                                   .ToList();

                if (filmeEspectadorLista.Count > 0)
                {
                    var listaNomeEspectadores = new List<string>();

                    foreach (var item in filmeEspectadorLista)
                    {
                        var espectador = _context.Espectadores.Where(h => h.Id == item.EspectadorId).FirstOrDefault();

                        if (!listaNomeEspectadores.Contains(item.Espectador.Nome))
                        {
                            listaNomeEspectadores.Add(espectador.Nome);
                        }
                    }

                    return Ok(listaNomeEspectadores);
                }

                return Ok("Nenhum espectador encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: /api/espectadorId
        //Lista o nome dos filmes assistidos por um espectador
        [HttpGet("listaFilmePorEspectador/{EspectadorId}")]
        public ActionResult GetEspectador(int EspectadorId)

        {
            try
            {
                var espectadorFilmeLista = _context.Filmes_Espectadores
                                   .Where(h => h.EspectadorId == EspectadorId)
                                   .ToList();

                if (espectadorFilmeLista.Count > 0)
                {
                    var listaNomeFilmes = new List<string>();

                    foreach (var item in espectadorFilmeLista)
                    {
                        var filme = _context.Filmes.Where(h => h.Id == item.FilmeId).FirstOrDefault();

                        if (!listaNomeFilmes.Contains(item.Filme.Título))
                        {
                            listaNomeFilmes.Add(filme.Título);
                        }
                    }

                    return Ok(listaNomeFilmes);
                }

                return Ok("Nenhum filme encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST: api/{filmeId, espectadorId}
        //Insere Id's referentes ao filme e ao espectador em tabela relacional
        [HttpPost]
        public ActionResult Post(int filmeId, int espectadorId, int score)
        {
            try
            {

                //Verificar se nao tem na lista a dupla filme - espectador

                var filmeEspectadorExistente = _context.Filmes_Espectadores
                                   .Where(h => h.FilmeId == filmeId && h.EspectadorId == espectadorId)
                                   .FirstOrDefault();

                if (filmeEspectadorExistente == null)
                {

                    var filmeEncontrado = _context.Filmes
                                  .Where(h => h.Id == filmeId)
                                  .FirstOrDefault();


                    if (filmeEncontrado != null)
                    {
                        var novoFilmeEspectador = new Filme_Espectador
                        {
                            EspectadorId = espectadorId,
                            FilmeId = filmeId,
                            Score = score
                        };

                        decimal novoScore = 0;
                        if (filmeEncontrado.Score != 0 && score > 0)
                        {
                            novoScore = (filmeEncontrado.Score + score) / 2;
                        }
                        else
                        {
                            novoScore = score;
                        }

                        filmeEncontrado.Score = novoScore;

                        _context.Filmes.Update(filmeEncontrado);
                        _context.Filmes_Espectadores.Add(novoFilmeEspectador);
                        _context.SaveChanges();
                        return Ok("OK");
                    }

                }
                return Ok("Algo errado.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

    }
}

