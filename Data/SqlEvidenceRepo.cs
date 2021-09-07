using Microsoft.EntityFrameworkCore;
using PhasmoRESTApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhasmoRESTApi.Data
{
    public class SqlEvidenceRepo : IEvidenceRepo
    {
        private readonly PhasmoContext _context;
        public SqlEvidenceRepo(PhasmoContext context)
        {
            _context = context;
        }
        public void CreateEvidence(Evidence evidence)
        {
            if (evidence == null)
            {
                throw new ArgumentNullException(nameof(evidence));
            }
            _context.Evidences.Add(evidence);
        }

        public void DeleteEvidence(Evidence evidence)
        {
            if (evidence == null)
            {
                throw new ArgumentNullException(nameof(evidence));
            }
            _context.Evidences.Remove(evidence);
        }

        public IEnumerable<Evidence> GetAllEvidence()
        {
            return _context.Evidences.ToList();
        }

        public Evidence GetEvidenceById(long id)
        {
            return _context.Evidences.FirstOrDefault(x => x.EvidenceId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateEvidence(Evidence evidence)
        {
            _context.Entry(evidence).State = EntityState.Modified;
        }
    }
}
