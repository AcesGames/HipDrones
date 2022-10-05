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
    public class PilotController : Controller
    {
        private IPilotService _pilotData;

        public PilotController(IPilotService pilotData)
        {
            _pilotData = pilotData;

        }

        public IActionResult Index()
        {
            return View(_pilotData.GetAll());
        }

        public IActionResult Details(int id)
        {
            var model = _pilotData.Get(id);
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
        public IActionResult Create(Pilot pilot)
        {
            if (ModelState.IsValid)
            {
                var tmp = new Pilot
                {
                    Name = pilot.Name,
                    Info = pilot.Info,
                    Available = pilot.Available

                };

                tmp = _pilotData.Add(tmp);

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

            var obj = _pilotData.GetAll().FirstOrDefault(m => m.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pilot obj)
        {
            if (obj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _pilotData.Update(obj);
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _pilotData.GetAll().FirstOrDefault(m => m.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            _pilotData.Delete(id);
            return RedirectToAction(nameof(Index));

        }
    }


}
