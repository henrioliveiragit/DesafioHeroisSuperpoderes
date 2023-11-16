using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using DesafioSuperHerois.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSuperHerois.Controllers
{
    [Route("v1")]
    [ApiController]
    public class HeroisSuperpoderesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public HeroisSuperpoderesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: herois
        [Route("herois")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetAllHerois()
        {
            var lista = await _context.HeroisSuperpoderes.Include("Herois")
                 .Select(h => new {
                    h.Id,
                    Nome = _context.Herois.FirstOrDefault(b => b.Id == h.HeroiId).Nome,
                    NomeHeroi = _context.Herois.FirstOrDefault(b => b.Id == h.HeroiId).NomeHeroi,
                    Altura = _context.Herois.FirstOrDefault(b => b.Id == h.HeroiId).Altura,
                    Peso = _context.Herois.FirstOrDefault(b => b.Id == h.HeroiId).Peso,
                     DataNascimento = _context.Herois.FirstOrDefault(b => b.Id == h.HeroiId).DataNascimento,
                    Superpoder = _context.Superpoderes.FirstOrDefault(b => b.Id == h.SuperpoderId).Superpoder,
                    Descricao = _context.Superpoderes.FirstOrDefault(b => b.Id == h.SuperpoderId).Descricao,
                 })
                .ToListAsync();
            return lista;
        }

        // GET: v1/GetHeroiById/{codigo}
        [Route("GetHeroiById")]
        [HttpGet]
        public async Task<ActionResult<object>> GetHeroiById(int id)
        {
            var heroisuperpoderes = await _context.HeroisSuperpoderes.FindAsync(id);


            if (heroisuperpoderes == null)
            {
              
            }

            var heroi = await _context.Herois.FindAsync(heroisuperpoderes.HeroiId);
            var obj = new
            {
                HeroiId = heroi.Id,
                HeroiSuperpoderId = heroisuperpoderes.Id,
                Nome = heroi.Nome,
                Peso = heroi.Peso,
                Altura = heroi.Altura,
                DataNascimento = heroi.DataNascimento,
                NomeHeroi = heroi.NomeHeroi,
                SuperpoderId = heroisuperpoderes.SuperpoderId,

            };
            return obj;
        }

        // DELETE: v1/{id}
        [HttpDelete("{id}")]
        public async Task<Boolean> DeleteHeroisSuperpoderes(int id)
        {
            var heroissuperpoderes = await _context.HeroisSuperpoderes.FindAsync(id);
            var herois = await _context.Herois.FindAsync(heroissuperpoderes.HeroiId);
            if (heroissuperpoderes == null)
            {
                return false;
            }
            if (herois == null)
            {
                return false;
            }
            _context.HeroisSuperpoderes.Remove(heroissuperpoderes);
            _context.Herois.Remove(herois);
            await _context.SaveChangesAsync();

            return true;
        }

        

        //POST: api/herois
        [Route("herois")]
        [HttpPost]
        public async Task<ActionResult<object>> PostHerois(Herois herois)
        {
            try
            {
                var lista = _context.Herois
                    .Where(a => a.NomeHeroi == herois.NomeHeroi)
                    .ToListAsync();
                var x = lista.Result;

               
                if (herois.Id == 0)
                {
                    if (x.Count >= 1)
                    {
                        var objretorno = new { msg = "Já existe um Herói com esse mesmo nome.", error = true };
                        return objretorno;
                    }
                    _context.Herois.Add(herois);
                    
                }
                else
                {
                    if (x.Count > 1)
                    {
                        var objretorno = new { msg = "Já existe um Herói com esse mesmo nome.", error = true };
                        return objretorno;
                    }
                    var objAntigo = _context.Herois.Find(herois.Id);
                    _context.Entry(objAntigo).CurrentValues.SetValues(herois);

                }

                await _context.SaveChangesAsync();
                return herois;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //POST: api/superpoderes
        [Route("superpoderes")]
        [HttpPost]
        public async Task<ActionResult<HeroisSuperpoderes>> PostSuperpoderes(int heroiid, int superpoderid)
        {
            try
            {
                HeroisSuperpoderes obj = new HeroisSuperpoderes();
                obj.SuperpoderId = superpoderid;
                obj.HeroiId = heroiid;
                obj.Id = 0;
                _context.HeroisSuperpoderes.Add(obj);
                await _context.SaveChangesAsync();

                return obj;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET: superpoderes
        [Route("superpoderes")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Superpoderes>>> GetAllSuperpoderes()
        {
            return await _context.Superpoderes.ToListAsync();
        }

        // GET: api/superpoderes/{codigo}
        [HttpGet("superpoderes/{codigo}")]
        public async Task<ActionResult<Superpoderes>> GetSuperpoderes(int id)
        {
            var superpoder = await _context.Superpoderes.FindAsync(id);
            if (superpoder == null)
            {
                return NotFound();
            }
            return superpoder;
        }
    }
}