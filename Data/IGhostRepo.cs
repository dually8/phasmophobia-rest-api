using System.Collections.Generic;
using PhasmoRESTApi.Models;

namespace PhasmoRESTApi.Data
{
    public interface IGhostRepo
    {
        bool SaveChanges();
        IEnumerable<Ghost> GetAllGhosts();
        Ghost GetGhostById(long id);
        void CreateGhost(Ghost ghost);
        void UpdateGhost(Ghost ghost);
        void DeleteGhost(Ghost ghost);
    }
}
