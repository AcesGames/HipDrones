using System.Collections.Generic;
using HipDronesProject.Data.Models;

namespace HipDronesProject.Interfaces
{
    public interface IDroneService
    {
        IEnumerable<Drone> GetAll();
        Drone Get(int id);
        Drone Add(Drone drone);
        Drone Update(Drone drone);
        void Delete(int id);
    }
}
