using System.Collections.Generic;
using PhasmoRESTApi.Models;

namespace PhasmoRESTApi.Data
{
    public interface IEvidenceRepo
    {
        bool SaveChanges();
        IEnumerable<Evidence> GetAllEvidence();
        Evidence GetEvidenceById(long id);
        void CreateEvidence(Evidence evidence);
        void UpdateEvidence(Evidence evidence);
        void DeleteEvidence(Evidence evidence);
    }
}
