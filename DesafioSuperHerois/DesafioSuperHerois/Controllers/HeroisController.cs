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
    [Route("api/Herois")]
    [ApiController]
    public class HeroisController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public HeroisController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Herois
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Herois>>> GetAll()
        {
            return await _context.Herois.ToListAsync();
        }

        // GET: api/Herois/{codigo}
        [HttpGet("{codigo}")]
        public async Task<ActionResult<Herois>> GetHeroi(int codigo)
        {
            var heroi = await _context.Herois.FindAsync(codigo);
            if (heroi == null)
            {
                return NotFound();
            }

            return heroi;
        }
    }
}