using DSS_LastVersion.Models;
using DSS_LastVersion.Repository;
using DSS_LastVersion.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSS_LastVersion.Controllers
{
    public class BrotherhoodController : Controller
    {
        private DBContext db;
        private readonly IBrotherhood Brotherhoods;
        public BrotherhoodController(DBContext _db, IBrotherhood _Brotherhoods)
        {
            db = _db;
            Brotherhoods = _Brotherhoods;
        }

        public IActionResult Index()
        {
            var model = Brotherhoods.GetBrotherhoods;
            return View(model.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brotherhood model)
        {
            if (ModelState.IsValid)
            {
                Brotherhoods.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Details(int ID)
        {
            return View(Brotherhoods.GetBrotherhood(ID));
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var model = Brotherhoods.GetBrotherhood(ID);
            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Brotherhood model)
        {
            if (ModelState.IsValid)
            {
                db.Brotherhoods.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
                var model = Brotherhoods.GetBrotherhood(ID);
                return View("Delete", model);
            
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int ID)
        {
                Brotherhoods.Remove(ID);
                return RedirectToAction("Index");
        }
    }
}
