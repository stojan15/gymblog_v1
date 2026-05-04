using gymblog1.Models;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static gymblog1.Models.IdentityModels;

namespace gymblog1.Controllers
{

    public class Post1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly PostService _service = new PostService();

        public ActionResult Index(string search, string sort, int page = 1)
        {
            var posts = _service.GetAll(search, sort, page);
            ViewBag.TodayMacros = db.MacroTrackers.OrderByDescending(m => m.Date).FirstOrDefault();
            return View(posts);
        }
        [HttpPost]
        public ActionResult SaveMacros(MacroTracker macros)
        {
            if (ModelState.IsValid)
            {
                macros.Date = DateTime.Now;
                db.MacroTrackers.Add(macros); 
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var post = _service.GetById(id);
            return View(post);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post post, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var directoryPath = Server.MapPath("~/images");

                // Provjeri postoji li folder images, ako ne - kreiraj ga
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                var path = Path.Combine(directoryPath, fileName);
                image.SaveAs(path);

                post.ImagePath = "/images/" + fileName;
            }

            post.CreatedAt = DateTime.Now;
            _service.Add(post);
            return RedirectToAction("Index");
        }

        public ActionResult Like(int id)
        {
            _service.Like(id);
            return RedirectToAction("Index");
        }
        public ActionResult Stats()
        {
        
            return View();
        }
        [AllowAnonymous]
        public ActionResult TeretanaBlog()
        {
            //. Uzmi sve postove
            var posts = _service.GetAll(null, null, 1);

            // 2. Uzmi tvoj zadnji unos makrosa iz baze (onih 180g proteina)
            var lastEntry = db.MacroTrackers.OrderByDescending(m => m.Date).FirstOrDefault();

            // Prosledi makrose u ViewBag da bi barovi radili dinamički
            ViewBag.TodayMacros = lastEntry;

            // 3. VRATI BAŠ OVAJ VIEW
            return View(posts);
        }

    }
}