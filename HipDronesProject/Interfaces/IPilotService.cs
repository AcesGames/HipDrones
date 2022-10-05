using System.Collections.Generic;
using HipDronesProject.Data.Models;

namespace HipDronesProject.Interfaces
{
    public interface IPilotService
    {
        IEnumerable<Pilot> GetAll();
        Pilot Get(int id);
        Pilot Add(Pilot pilot);
        Pilot Update(Pilot pilot);
        void Delete(int id);
    }
}
