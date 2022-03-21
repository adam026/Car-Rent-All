using Car_Rent_All.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Car_Rent_All.Controllers
{
    public class UgyfelekController : Controller
    {
        private ApplicationDbContext _context;

        public UgyfelekController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // GET: Ugyfelek
        public ActionResult Index()
        {
            if (User.IsInRole("CanManage"))
                return View("AdminLista");
            else
            {
                var ugyfel = _context.Ugyfelek.SingleOrDefault(x => x.Email == User.Identity.Name);
                if (ugyfel is null)
                {
                    var atadott = new Ugyfel { Id = 0, Email = User.Identity.Name };
                    return View("UgyfelForm", atadott);
                }
                else
                    return View("UgyfelForm", ugyfel);
            }

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Ugyfel ugyfel)
        {
            if (!ModelState.IsValid)
            {
                var visszaadottUgyfel = ugyfel;

                return View("UgyfelForm", ugyfel);
            }


            if (ugyfel.Id == 0)
            {
                _context.Ugyfelek.Add(ugyfel);
            }
            else
            {
                var ugyfelInDb = _context.Ugyfelek.Single(u => u.Id == ugyfel.Id);

                ugyfelInDb.Nev = ugyfel.Nev;
                ugyfelInDb.Cim = ugyfel.Cim;
                ugyfelInDb.SzuletesiDatum = ugyfel.SzuletesiDatum;
                ugyfelInDb.Jogositvany = ugyfel.Jogositvany;
                ugyfelInDb.Telefonszam = ugyfel.Telefonszam;
                ugyfelInDb.Email = ugyfel.Email;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Ugyfelek");
        }

        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult Edit(int id)
        {
            var ugyfel = _context.Ugyfelek.SingleOrDefault(u => u.Id == id);
            if (ugyfel is null) 
                return HttpNotFound();
            else
            {
                var szerkesztendoUgyfel = ugyfel;
                return View("UgyfelForm", szerkesztendoUgyfel);
            }
        }

        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult New()
        {
            var ugyfel = new Ugyfel { Id = 0 };
            return View("UgyfelForm", ugyfel);
        }
    }
}