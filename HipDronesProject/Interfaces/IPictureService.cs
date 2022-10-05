using System.Collections.Generic;
using HipDronesProject.Data.Models;

namespace HipDronesProject.Interfaces
{
    public interface IPictureService
    {
        IEnumerable<Picture> GetAll();
        Picture Get(int id);
        Picture Add(Picture asset);
        Picture Update(Picture asset);
        void Delete(int id);
    }
}
