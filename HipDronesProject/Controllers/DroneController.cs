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
    public class DroneController : Controller
    {
        private IDroneService _droneData;

        public DroneController(IDroneService droneData)
        {
            _droneData = droneData;

        }

        public IActionResult Index()
        {
            return View(_droneData.GetAll());
        }

        public IActionResult Details(int id)
        {
            var model = _droneData.Get(id);
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
        public IActionResult Create(Drone drone)
        {
            if (ModelState.IsValid)
            {
                var tmpDrone = new Drone
                {
                    Name = drone.Name,
                    RegId = drone.RegId,
                    Category = drone.Category,
                    Info = drone.Info,
                    Available = drone.Available
                };

                tmpDrone = _droneData.Add(tmpDrone);

                return RedirectToAction(nameof(Index), new { id = tmpDrone.Id });
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drone = _droneData.GetAll().FirstOrDefault(m => m.Id == id);
            if (drone == null)
            {
                return NotFound();
            }
            return View(drone);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Drone drone)
        {
            if (drone == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _droneData.Update(drone);
                return RedirectToAction(nameof(Index));
            }

            return View(drone);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drone = _droneData.GetAll().FirstOrDefault(m => m.Id == id);

            if (drone == null)
            {
                return NotFound();
            }

            return View();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            _droneData.Delete(id);
            return RedirectToAction(nameof(Index));

        }
    }


}
