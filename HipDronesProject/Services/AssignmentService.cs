using System.Collections.Generic;
using System.Linq;
using HipDronesProject.Data;
using HipDronesProject.Data.Models;
using HipDronesProject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HipDronesProject.Services
{
    public class AssignmentServiceService : IAssignmentService
    {
        private ApplicationDbContext _context;

        public AssignmentServiceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Assignment> GetAll()
        {
            return _context.Assignments.Include(x=>x.Pilot).OrderBy(i => i.Id);
        }

        public Assignment Get(int id)
        {
            return GetAll().FirstOrDefault(a => a.Id == id);
        }

        public Assignment Add(Assignment assignment)
        {
            _context.Add(assignment);
            _context.SaveChanges();
            return assignment;
        }

        public Assignment Update(Assignment assignment)
        {
            _context.Assignments.Attach(assignment).State = EntityState.Modified;
            _context.SaveChanges();
            return assignment;
        }

      public void Delete(int id)
        {
            _context.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}
