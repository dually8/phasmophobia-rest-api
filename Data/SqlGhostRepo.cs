using PhasmoRESTApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PhasmoRESTApi.Data
{
    public class SqlGhostRepo : IGhostRepo
    {
        private readonly PhasmoContext _context;
        public SqlGhostRepo(PhasmoContext context)
        {
            _context = context;
        }
        public void CreateGhost(Ghost ghost)
        {
            if (ghost == null)
            {
                throw new ArgumentNullException(nameof(ghost));
            }
            _context.Ghosts.Add(ghost);
        }

        public void DeleteGhost(Ghost ghost)
        {
            if (ghost == null)
            {
                throw new ArgumentNullException(nameof(ghost));
            }
            _context.Ghosts.Remove(ghost);
        }

        public IEnumerable<Ghost> GetAllGhosts()
        {
            return _context.Ghosts.Include(x => x.Ghost_Evidences).ToList();
        }

        public Ghost GetGhostById(long id)
        {
            return _context.Ghosts.Include(x => x.Ghost_Evidences).FirstOrDefault(x => x.GhostId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateGhost(Ghost ghost)
        {
            _context.Entry(ghost).State = EntityState.Modified;
        }
    }
}
