using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhasmoRESTApi.Models;
using PhasmoRESTApi.Dtos;

namespace PhasmoRESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvidenceController : ControllerBase
    {
        private readonly PhasmoContext _context;
        private readonly IMapper _mapper;

        public EvidenceController(PhasmoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Evidence
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvidenceReadDto>>> GetEvidences()
        {
            var evidences = await _context.Evidences.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<EvidenceReadDto>>(evidences));
        }

        // GET: api/Evidence/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evidence>> GetEvidence(long id)
        {
            var evidence = await _context.Evidences.FindAsync(id);

            if (evidence == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EvidenceReadDto>(evidence));
        }

        // PUT: api/Evidence/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutEvidence(long id, Evidence evidence)
        // {
        //     if (id != evidence.EvidenceId)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(evidence).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!EvidenceExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // POST: api/Evidence
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Evidence>> PostEvidence(EvidenceCreateDto evidenceCreateDto)
        {
            if (EvidenceExists(evidenceCreateDto.Name))
            {
                return StatusCode(StatusCodes.Status303SeeOther);
            }
            var evidence = _mapper.Map<Evidence>(evidenceCreateDto);

            _context.Evidences.Add(evidence);
            await _context.SaveChangesAsync();

            var readDto = _mapper.Map<EvidenceReadDto>(evidence);
            return CreatedAtAction(nameof(GetEvidence), new { Id = readDto.EvidenceId }, readDto);
            // _context.Evidences.Add(evidence);
            // await _context.SaveChangesAsync();

            // return CreatedAtAction("GetEvidence", new { id = evidence.EvidenceId }, evidence);
        }

        // DELETE: api/Evidence/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvidence(long id)
        {
            var evidence = await _context.Evidences.FindAsync(id);
            if (evidence == null)
            {
                return NotFound();
            }

            _context.Evidences.Remove(evidence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EvidenceExists(long id)
        {
            return _context.Evidences.Any(e => e.EvidenceId == id);
        }

        private bool EvidenceExists(string name)
        {
            return _context.Evidences.Any(e => e.Name.ToLower() == name.ToLower());
        }
    }
}
