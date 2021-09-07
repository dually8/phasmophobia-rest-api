using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PhasmoRESTApi.Data;
using PhasmoRESTApi.Models;
using PhasmoRESTApi.Dtos;

namespace PhasmoRESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvidencesController : ControllerBase
    {

        private readonly IEvidenceRepo _repo;
        private readonly IMapper _mapper;
        public EvidencesController(IEvidenceRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/Evidences
        [HttpGet]
        public ActionResult<IEnumerable<EvidenceReadDto>> GetEvidences()
        {
            var evidences = _repo.GetAllEvidence();
            return Ok(_mapper.Map<IEnumerable<EvidenceReadDto>>(evidences));
        }

        // GET: api/Evidences/5
        [HttpGet("{id}", Name = "GetEvidenceById")]
        public ActionResult<EvidenceReadDto> GetEvidenceById(long id)
        {
            var evidence = _repo.GetEvidenceById(id);
            if (evidence != null)
            {
                return Ok(_mapper.Map<EvidenceReadDto>(evidence));
            }
            return NotFound();
        }

        // POST: api/Evidences
        [HttpPost]
        public ActionResult<EvidenceReadDto> CreateEvidence(EvidenceCreateDto evidenceCreateDto)
        {
            // Don't create it if it already exists
            if (DoesEvidenceExist(evidenceCreateDto))
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status303SeeOther);
            }
            var evidence = _mapper.Map<Evidence>(evidenceCreateDto);
            _repo.CreateEvidence(evidence);
            _repo.SaveChanges();

            var evidenceReadDto = _mapper.Map<EvidenceReadDto>(evidence);

            return CreatedAtAction(nameof(GetEvidenceById), new { Id = evidenceReadDto.EvidenceId }, evidenceReadDto);
        }

        //PUT api/Evidences/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEvidence(long id, EvidenceUpdateDto evidenceUpdateDto)
        {
            var evidenceFromRepo = _repo.GetEvidenceById(id);
            if (evidenceFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(evidenceUpdateDto, evidenceFromRepo);

            _repo.UpdateEvidence(evidenceFromRepo);

            _repo.SaveChanges();

            return NoContent();
        }

        private bool DoesEvidenceExist(EvidenceCreateDto evidenceCreateDto)
        {
            var evidence = _repo.GetAllEvidence().FirstOrDefault(ev => ev.Name.ToLower() == evidenceCreateDto.Name.ToLower());
            if (evidence != null)
            {
                return true;
            }
            return false;
        }
    }
}
