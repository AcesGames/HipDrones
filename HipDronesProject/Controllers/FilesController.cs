using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HipDronesProject.Data.Models;
using HipDronesProject.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;

namespace HipDronesProject.Controllers
{
    public class FilesController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IPictureService _pictureService;

        public FilesController(IWebHostEnvironment env, IPictureService pictureService)
        {
            _pictureService = pictureService;
            _env = env;
        }

        public IActionResult Media()
        {
            return View();
        }

        public IActionResult PictureIndex()
        {
            return View();
        }

        public IActionResult Gallery()
        {

            
            return View();
        }

        [HttpGet]
        public IActionResult UploadPicture()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> UploadPicture(Picture model)
        {
            if (model.ImageFile.Length > 0)
            {
                string path = Path.Combine(_env.WebRootPath, "images/uploaded");
                using (var fs = new FileStream(Path.Combine(path, model.ImageFile.FileName), FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fs);
                }

               

            }

            return Ok(model);
        }


        [HttpGet]
        public async Task<IActionResult> Details(Picture model)
        {
            var file = model.ImageFile;

            string path = Path.Combine(_env.WebRootPath, "images/uploaded");
            using (var fs = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            using (var img = Image.Load(Path.Combine(path, file.FileName)))
            {
                model.Source = $"/images/uploaded/{file.FileName}";
                model.Path = Path.GetExtension(file.FileName).Substring(1);
                model.Width = img.Width;
                model.Height = img.Height;
                model.Size = file.Length / 1000;
                if (model.Latitude != null)
                    model.Latitude =
                        img.Metadata.ExifProfile.GetValue(ExifTag.GPSLatitude).ToString();
                if (model.Longitude != null)
                    model.Longitude =
                        img.Metadata.ExifProfile.GetValue(ExifTag.GPSLongitude).ToString();
                if (model.Altitude != null)
                    model.Altitude =
                        img.Metadata.ExifProfile.GetValue(ExifTag.GPSAltitude).ToString();

                return Ok(model);

            }
        }
    }
}








