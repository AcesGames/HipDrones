using System.Collections.Generic;
using System.Linq;
using HipDronesProject.Data;
using HipDronesProject.Data.Models;
using HipDronesProject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HipDronesProject.Services
{
    public class CustomerService : ICustomerService
    {
        private ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.OrderBy(i => i.Id);
        }


        public Customer Get(int id)
        {
            return GetAll().FirstOrDefault(d => d.Id == id);
        }

        public Customer Add(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer Update(Customer customer)
        {
            _context.Customers.Attach(customer).State = EntityState.Modified;
            _context.SaveChanges();
            return customer;
        }

        public void Delete(int id)
        {
            _context.Customers.Remove(Get(id));
            _context.SaveChanges();

        }
        
    }
}
