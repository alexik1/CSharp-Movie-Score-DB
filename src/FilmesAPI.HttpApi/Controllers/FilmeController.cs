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
        public class FilmeController : ControllerBase
        {
            public readonly FilmesAPIDbContext _context;
            public FilmeController(FilmesAPIDbContext context)
            {
                _context = context;
            }


            // GET api/filme
            //Lista todos os filmes por tabela FK
            [HttpGet]
            public ActionResult Get()
            {
                //var listFilme = _context.Filmes.ToList();
                var listaFilme = (from Filme in _context.Filmes select Filme).ToList();
                return Ok(listaFilme);
            }

            // GET api/filtro/{Título}
            //Filtra a requisição por trechos do título
            [HttpGet("filtro/{Título}")]
            public ActionResult GetFiltro(string Título)
            {
                var listaFilme = _context.Filmes
                                  .Where(h => h.Título.Contains(Título))
                                  .ToList();
                //var listFilme = (from Filme in _context.Filmes select Filme).ToList();
                return Ok(listaFilme);
            }

            // GET api/{Id}
            //Filtra a requisição por Id
            [HttpGet("{Id}")]
            public ActionResult GetId(int Id)
            {
                var listaFilme = _context.Filmes
                                  .Where(h => h.Id == Id)
                                  .ToList();
                //var listFilme = (from Filme in _context.Filmes select Filme).ToList();
                return Ok(listaFilme);
            }

            // POST api/{Título}
            [HttpPost("{Título}")]
            public ActionResult<string> Post(string Título)
            {
                var filme = new Filme { Título = Título };

                var listaFilme = _context.Espectadores
                                  .Where(h => h.Nome.Contains(Título));

                _context.Add(filme);
                _context.SaveChanges();
                return Ok(listaFilme);
            }

            // PUT api/{id, título}
            [HttpPut]
            public async Task<IActionResult> Put(int filmeid, string novoTitulo)
            {
                var filmeExistente = _context.Filmes
                                   .Where(h => h.Id == filmeid)
                                   .FirstOrDefault();
                if (filmeExistente != null)
                {
                    filmeExistente.Título = novoTitulo;
                    _context.Filmes.Update(filmeExistente);
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }

            // DELETE api/{id}
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                var filme = _context.Filmes.Where(x => x.Id == id).Single();
                _context.Filmes.Remove(filme);
                _context.SaveChanges();
            }
        }
    }

