using System.Collections.Generic;
using System.Linq;
using HipDronesProject.Data;
using HipDronesProject.Data.Models;
using HipDronesProject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HipDronesProject.Services
{
    public class DroneService : IDroneService
    {
        private ApplicationDbContext _context;

        public DroneService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Drone> GetAll()
        {
            return _context.Drones.OrderBy(i => i.Id);
        }

        public Drone Get(int id)
        {
            return GetAll().FirstOrDefault(d => d.Id == id);
        }

        public Drone Add(Drone drone)
        {
            _context.Add(drone);
            _context.SaveChanges();
            return drone;
        }

        public Drone Update(Drone drone)
        {
            _context.Drones.Attach(drone).State = EntityState.Modified;
            _context.SaveChanges();
            return drone;
        }

        public void Delete(int id)
        {
            _context.Drones.Remove(Get(id));
            _context.SaveChanges();

        }

    }
}
