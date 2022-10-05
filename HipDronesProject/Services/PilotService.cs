using System.Collections.Generic;
using System.Linq;
using HipDronesProject.Data;
using HipDronesProject.Data.Models;
using HipDronesProject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HipDronesProject.Services
{
    public class PilotService : IPilotService
    {
        private ApplicationDbContext _context;

        public PilotService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pilot> GetAll()
        {
            return _context.Pilots.OrderBy(i => i.Id);

        }

        public Pilot Get(int id)
        {
            return GetAll().FirstOrDefault(p => p.Id == id);
        }

        public Pilot Add(Pilot pilot)
        {
            _context.Add(pilot);
            _context.SaveChanges();
            return pilot;
        }

        public Pilot Update(Pilot pilot)
        {
            _context.Pilots.Attach(pilot).State = EntityState.Modified;
            _context.SaveChanges();
            return pilot;
        }

        public void Delete(int id)
        {
            _context.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}
