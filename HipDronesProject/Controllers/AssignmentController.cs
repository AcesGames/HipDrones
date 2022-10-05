using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HipDronesProject.Data;
using HipDronesProject.Data.Models;
using HipDronesProject.Interfaces;
using HipDronesProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace HipDronesProject.Controllers
{
    public class AssignmentController : Controller
    {
        private IAssignmentService _assignmentServiceData;
        private readonly IPilotService pilotService;

        public AssignmentController(IAssignmentService assignmentServiceData, IPilotService pilotService)
        {
            _assignmentServiceData = assignmentServiceData;
            this.pilotService = pilotService;

        }

        public IActionResult Index()
        {
            return View(_assignmentServiceData.GetAll());
        }

        public IActionResult Details(int id)
        {
            var model = _assignmentServiceData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AssignmentViewModel model = new AssignmentViewModel();

            var pilots = pilotService.GetAll().Where(x => x.Available).OrderBy(x => x.Name);

            foreach (var pilot in pilots)
            {
                model.Pilots.Add(new SelectListItem(pilot.Name, pilot.Id.ToString()));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AssignmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pilot = pilotService.Get(int.Parse(model.PilotId));

                var tmp = new Assignment
                {
                    Pilot = pilot,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Type = model.Type,
                    Paid = model.Paid

                };

                tmp = _assignmentServiceData.Add(tmp);

                return RedirectToAction(nameof(Details), new { id = tmp.Id });
            }

            return View(model);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = _assignmentServiceData.Get(id.Value);

            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Assignment assignment)
        {
            if (assignment == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _assignmentServiceData.Update(assignment);
                return RedirectToAction(nameof(Index));
            }

            return View(assignment);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = _assignmentServiceData.GetAll().FirstOrDefault(m => m.Id == id);

            if (assignment == null)
            {
                return NotFound();
            }

            return View();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            _assignmentServiceData.Delete(id);
            return RedirectToAction(nameof(Index));

        }
    }


}
