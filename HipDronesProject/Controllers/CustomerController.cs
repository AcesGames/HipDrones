using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HipDronesProject.Data;
using HipDronesProject.Data.Models;
using HipDronesProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HipDronesProject.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _customerData;

        public CustomerController(ICustomerService customerData)
        {
            _customerData = customerData;

        }

        public IActionResult Index()
        {
            return View(_customerData.GetAll());
        }

        public IActionResult Details(int id)
        {
            var model = _customerData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var tmp = new Customer
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email
                    };

                tmp = _customerData.Add(tmp);

                return RedirectToAction(nameof(Index), new { id = tmp.Id });
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerData.GetAll().FirstOrDefault(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            if (customer == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _customerData.Update(customer);
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerData.GetAll().FirstOrDefault(m => m.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            _customerData.Delete(id);
            return RedirectToAction(nameof(Index));

        }
    }


}
