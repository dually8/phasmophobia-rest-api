using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PhasmoRESTApi.Models;
using PhasmoRESTApi.Dtos;

namespace PhasmoRESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GhostController : ControllerBase
    {
        private readonly PhasmoContext _context;
        private readonly IMapper _mapper;

        public GhostController(PhasmoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Ghost
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GhostReadDto>>> GetGhosts()
        {
            var ghosts = await _context.Ghosts.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<GhostReadDto>>(ghosts));
            // return await _context.Ghosts.ToListAsync();
        }

        // GET: api/Ghost/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GhostReadDto>> GetGhost(long id)
        {
            var ghost = await _context.Ghosts.FindAsync(id);

            if (ghost == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GhostReadDto>(ghost));
        }

        // PUT: api/Ghost/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGhost(long id, GhostUpdateDto ghostUpdateDto)
        {
            var ghost = _context.Ghosts.SingleOrDefault(x => x.GhostId == id);
            if (ghost == null)
            {
                return NotFound();
            }

            _mapper.Map(ghostUpdateDto, ghost);
            _context.Entry(ghost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

            return NoContent();
            // if (id != ghost.GhostId)
            // {
            //     return BadRequest();
            // }

            // _context.Entry(ghost).State = EntityState.Modified;

            // try
            // {
            //     await _context.SaveChangesAsync();
            // }
            // catch (DbUpdateConcurrencyException)
            // {
            //     if (!GhostExists(id))
            //     {
            //         return NotFound();
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }

            // return NoContent();
        }

        // POST: api/Ghost
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ghost>> PostGhost(GhostCreateDto ghostCreateDto)
        {
            var dbModel = _mapper.Map<Ghost>(ghostCreateDto);

            _context.Ghosts.Add(dbModel);
            await _context.SaveChangesAsync();

            var readDto = _mapper.Map<GhostReadDto>(dbModel);

            return CreatedAtAction(nameof(GetGhost), new { Id = readDto.GhostId }, readDto);
            // _context.Ghosts.Add(ghost);
            // await _context.SaveChangesAsync();

            // return CreatedAtAction("GetGhost", new { id = ghost.GhostId }, ghost);
        }

        // DELETE: api/Ghost/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGhost(long id)
        {
            var ghost = await _context.Ghosts.FindAsync(id);
            if (ghost == null)
            {
                return NotFound();
            }

            _context.Ghosts.Remove(ghost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GhostExists(long id)
        {
            return _context.Ghosts.Any(e => e.GhostId == id);
        }
    }
}
