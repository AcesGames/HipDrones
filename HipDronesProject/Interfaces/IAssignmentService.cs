using System.Collections.Generic;
using HipDronesProject.Data.Models;

namespace HipDronesProject.Interfaces
{
    public interface IAssignmentService
    {
        IEnumerable<Assignment> GetAll();
        Assignment Get(int id);
        Assignment Add(Assignment assignment);
        Assignment Update(Assignment assignment);
        void Delete(int id);
    }
}
