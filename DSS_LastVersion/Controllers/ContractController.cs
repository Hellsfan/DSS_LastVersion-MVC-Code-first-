using DSS_LastVersion.Models;
using DSS_LastVersion.Repository;
using DSS_LastVersion.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSS_LastVersion.Controllers
{
    public class ContractController : Controller
    {
        private DBContext db;
        private readonly IContract _Contract;
        private readonly IMission _Mission;
        private readonly IAssassin _Assassin;

        public ContractController(DBContext _db,IContract _IContract, IMission _IMission, IAssassin _IAssassin)
        {
            db = _db;
            _Contract = _IContract;
            _Mission = _IMission;
            _Assassin = _IAssassin;
        }

        public IActionResult Index()
        {
            return View(_Contract.GetContracts.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["AssassinID"] = new SelectList(db.Assassins, "AssassinID", "AssassinName");
            ViewData["MissionID"] = new SelectList(db.Missions, "MissionID", "MissionName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contract model)
        {
            if (ModelState.IsValid)
            {
                _Contract.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
                Contract model = _Contract.GetContract(ID);
                return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int ID)
        {
            _Contract.Remove(ID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var model = _Contract.GetContract(ID);
            ViewData["AssassinID"] = new SelectList(db.Assassins, "AssassinID", "AssassinName");
            ViewData["MissionID"] = new SelectList(db.Missions, "MissionID", "MissionName");
            ViewData["ContractID"] = new SelectList(db.Contracts, "ContractID", "ContractName");
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Contract model)
        {
            if (ModelState.IsValid)
            {
                db.Contracts.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Details(int ID)
        {
            return View(_Contract.GetContract(ID));
        }
    }
}
