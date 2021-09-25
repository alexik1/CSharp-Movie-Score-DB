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
    public class EspectadorController : ControllerBase
    {
        public readonly FilmesAPIDbContext _context;
        public EspectadorController(FilmesAPIDbContext context)
        {
            _context = context;
        }


        // GET api/filme
        //Lista todos os filmes
        [HttpGet]
        public ActionResult Get()
        {
            //var listFilme = _context.Filmes.ToList();
            var listaEspectador = (from Espectador in _context.Espectadores select Espectador).ToList();
            return Ok(listaEspectador);
        }

        // GET api/filtro/{Nome}
        //Filtra a requisição por trechos do Nome
        [HttpGet("filtro/{Nome}")]
        public ActionResult GetFiltro(string Nome)
        {
            var listaEspectador = _context.Espectadores
                              .Where(h => h.Nome.Contains(Nome))
                              .ToList();
            //var listFilme = (from Filme in _context.Filmes select Filme).ToList();
            return Ok(listaEspectador);
        }

        // GET api/{Id}
        //Filtra a requisição por Id
        [HttpGet("{Id}")]
        public ActionResult GetId(int Id)
        {
            var listaEspectador = _context.Espectadores
                              .Where(h => h.Id == Id)
                              .ToList();
            //var listFilme = (from Filme in _context.Filmes select Filme).ToList();
            return Ok(listaEspectador);
        }

        // POST api/{Nome}
        [HttpPost("{Nome}")]
        public ActionResult<string> Post(string Nome)
        {
            var espectador = new Espectador { Nome = Nome };

            var listaEspectador = _context.Espectadores
                              .Where(h => h.Nome.Contains(Nome));

            _context.Add(espectador);
            _context.SaveChanges();
            return Ok(listaEspectador);
        }

        // PUT api/{id, novonome}
        [HttpPut]
        public async Task<IActionResult> Put(int id, string novoNome)
        {
            var nomeExistente = _context.Espectadores
                               .Where(h => h.Id == id)
                               .FirstOrDefault();
            if (nomeExistente != null)
            {
                nomeExistente.Nome = novoNome;
                _context.Espectadores.Update(nomeExistente);
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
            var espectador = _context.Espectadores.Where(x => x.Id == id).Single();
            _context.Espectadores.Remove(espectador);
            _context.SaveChanges();
        }
    }
}

