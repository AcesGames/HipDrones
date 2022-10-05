using System.Collections.Generic;
using HipDronesProject.Data.Models;

namespace HipDronesProject.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
        Customer Add(Customer customer);
        Customer Update(Customer customer);
        void Delete(int id);
    }
}
