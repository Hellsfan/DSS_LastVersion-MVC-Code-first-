using DSS_LastVersion.Models;
using DSS_LastVersion.Repository;
using DSS_LastVersion.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSS_LastVersion.Controllers
{
    public class AssassinController : Controller
    {
        private readonly IAssassin _Assassin;
        private readonly IBrotherhood _Brotherhood;
        private DBContext db;

        public AssassinController(IAssassin _IAssassin,IBrotherhood _IBrotherhood, DBContext _db)
        {
            _Assassin = _IAssassin;
            _Brotherhood = _IBrotherhood;
            db = _db;
        }

        public IActionResult Index()
        {
            var model = _Assassin.GetAssassins;
            return View(model.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["BrotherhoodId"] = new SelectList(db.Brotherhoods, "BrotherhoodId", "BrotherhoodName");
            //ViewBag.Brotherhoods = _Brotherhood.GetBrotherhoods;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Assassin model)
        {
            if (ModelState.IsValid)
            {
                _Assassin.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int ID)
        {
            Assassin model = _Assassin.GetAssassin(ID);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int ID)
        {
            _Assassin.Remove(ID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int ID)
        {
            return View(_Assassin.GetAssassin(ID));
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            ViewData["BrotherhoodID"] = new SelectList(db.Brotherhoods, "BrotherhoodId", "BrotherhoodName");
            var model = _Assassin.GetAssassin(ID);
            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Assassin model)
        {
            if (ModelState.IsValid)
            {
                db.Assassins.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
