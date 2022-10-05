using System.Collections.Generic;
using System.Linq;
using HipDronesProject.Data;
using HipDronesProject.Data.Models;
using HipDronesProject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HipDronesProject.Services
{
    public class PictureService : IPictureService
    {
        private ApplicationDbContext _context;

        public PictureService(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Picture> GetAll()
        {
            return _context.Pictures.OrderBy(i => i.Id);

        }

        public Picture Get(int id)
        {
            return GetAll().FirstOrDefault(asset => asset.Id == id);
        }

        public Picture Add(Picture asset)
        {
            _context.Add(asset);
            _context.SaveChanges();
            return asset;
        }

        public Picture Update(Picture asset)
        {
            _context.Pictures.Attach(asset).State = EntityState.Modified;
            _context.SaveChanges();
            return asset;
        }

        public void Delete(int id)
        {
            _context.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}
