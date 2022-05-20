using DSS_LastVersion.Models;
using DSS_LastVersion.Repository;
using DSS_LastVersion.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSS_LastVersion.Controllers
{
    public class MissionController : Controller
    {
        private DBContext db;
        private readonly IMission Missions;
        public MissionController(DBContext _db, IMission _Missions)
        {
            db = _db;
            Missions = _Missions;
        }

        public IActionResult Index()
        {
            var model = Missions.GetMissions;
            return View(model.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Mission model)
        {
            if (ModelState.IsValid)
            {
                Missions.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Details(int ID)
        {
            return View(Missions.GetMission(ID));
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var model = Missions.GetMission(ID);
            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Mission model)
        {
            if (ModelState.IsValid)
            {
                db.Missions.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            var model = Missions.GetMission(ID);
            return View("Delete", model);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int ID)
        {
            Missions.Remove(ID);
            return RedirectToAction("Index");
        }
    }
}
