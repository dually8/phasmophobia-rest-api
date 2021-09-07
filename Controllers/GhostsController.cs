using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Linq;
using PhasmoRESTApi.Data;
using PhasmoRESTApi.Models;
using PhasmoRESTApi.Dtos;

namespace PhasmoRESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GhostsController : ControllerBase
    {

        private readonly IGhostRepo _repo;
        private readonly IMapper _mapper;
        public GhostsController(IGhostRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/Ghosts
        [HttpGet]
        public ActionResult<IEnumerable<GhostReadDto>> GetGhosts()
        {
            var ghosts = _repo.GetAllGhosts();
            return Ok(_mapper.Map<IEnumerable<GhostReadDto>>(ghosts));
        }

        // GET: api/Ghosts/5
        [HttpGet("{id}", Name = "GetGhostById")]
        public ActionResult<GhostReadDto> GetGhostById(long id)
        {
            var ghost = _repo.GetGhostById(id);
            if (ghost != null)
            {
                return Ok(_mapper.Map<GhostReadDto>(ghost));
            }
            return NotFound();
        }

        // POST: api/Ghosts
        [HttpPost]
        public ActionResult<GhostReadDto> CreateGhost(GhostCreateDto ghostCreateDto)
        {
            Ghost ghost = new Ghost()
            {
                Description = ghostCreateDto.Description,
                Name = ghostCreateDto.Name,
                Strengths = ghostCreateDto.Strengths,
                Weaknesses = ghostCreateDto.Weaknesses
            };
            _repo.CreateGhost(ghost);
            _repo.SaveChanges();

            ghost.Ghost_Evidences = ghostCreateDto.EvidenceIds.Select(ev => new Ghost_Evidence() {
                EvidenceId = ev,
                GhostId = ghost.GhostId
            }).ToList();

            _repo.UpdateGhost(ghost);
            _repo.SaveChanges();

            var ghostReadDto = _mapper.Map<GhostReadDto>(ghost);

            return CreatedAtAction(nameof(GetGhostById), new { Id = ghostReadDto.GhostId }, ghostReadDto);
        }

        //PUT api/Ghosts/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateGhost(long id, GhostUpdateDto GhostUpdateDto)
        {
            var ghostFromRepo = _repo.GetGhostById(id);
            if (ghostFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(GhostUpdateDto, ghostFromRepo);

            _repo.UpdateGhost(ghostFromRepo);

            _repo.SaveChanges();

            return NoContent();
        }
    }
}
