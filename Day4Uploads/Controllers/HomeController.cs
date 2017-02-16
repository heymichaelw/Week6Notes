using Day4Uploads.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day4Uploads.Controllers
{
    public class HomeController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.ImageUploads);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Upload()
        {
            var UploadViewModel = new ImageUploadViewModel();
            return View(UploadViewModel);
        }

        [HttpPost]
        public ActionResult Upload(ImageUploadViewModel formData)
        {
            var uploadedFile = Request.Files[0];
            string filename = $"{DateTime.Now.Ticks}{uploadedFile.FileName}";
            var serverpath = Server.MapPath(@"~\Uploads");
            var fullpath = Path.Combine(serverpath, filename);
            uploadedFile.SaveAs(fullpath);

            var uploadModel = new ImageUpload
            {
                Caption = formData.Caption,
                File = filename
            };
            db.ImageUploads.Add(uploadModel);
            db.SaveChanges();

            return View();
        }
    }
}