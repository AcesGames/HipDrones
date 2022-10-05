//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;
//using HipDronesProject.Data;
//using HipDronesProject.Data.Interfaces;
//using HipDronesProject.Data.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;


//namespace HipDronesProject.Controllers
//{
//    public class MeasureController : Controller
//    {
//        private IMediaData _mediaData;

//        public MeasureController(IMediaData mediaData)
//        {
//            _mediaData = mediaData;

//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Details(int id)
//        {
//            var model = _mediaData.Get(id);
//            if (model == null)
//            {
//                return RedirectToAction("Index", "Home");
//            }

//            return View();
//        }

//        [HttpGet]
//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create(Measurement measurement)
//        {
//            if (ModelState.IsValid)
//            {
//                var tmp = new Measurement
//                {
//                    FileName = measurement.FileName
                    
//                };

//                tmp = (Measurement) _mediaData.Add(tmp);

//                return RedirectToAction(nameof(Index), new { id = tmp.Id });
//            }
//            return View();
//        }

//        public IActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var measure = _mediaData.GetAll().FirstOrDefault(m => m.Id == id);
//            if (measure == null)
//            {
//                return NotFound();
//            }
//            return View(measure);
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(Measurement measure)
//        {
//            if (measure == null)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                _mediaData.Update(measure);
//                return RedirectToAction(nameof(Index));
//            }

//            return View(measure);
//        }


//        public IActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var measure = _mediaData.GetAll().FirstOrDefault(m => m.Id == id);

//            if (measure == null)
//            {
//                return NotFound();
//            }

//            return View();
//        }


//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(int id)
//        {

//            _mediaData.Delete(id);
//            return RedirectToAction(nameof(Index));

//        }
//    }


//}
