using Car_Rent_All.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var meghivoUgyfel = _context.Ugyfelek.SingleOrDefault(u => u.Email == User.Identity.Name);
                if (meghivoUgyfel is null)
                    return RedirectToAction("New", "Ugyfelek");
                else
                    return View("UgyfelLista", meghivoUgyfel);
            }

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Ugyfel ugyfel)
        {
            if (!ModelState.IsValid)
            {
                var visszaadottUgyfel = ugyfel;

                if (User.IsInRole("CanManage"))
                    return View("UgyfelForm", ugyfel);
                else
                    return View("UgyfelLista", ugyfel);
            }


            if (ugyfel.Id == 0)
            {
                _context.Ugyfelek.Add(ugyfel);
            }
            else
            {
                var ugyfelInDb = _context.Ugyfelek.Single(u => u.Id == ugyfel.Id);
                var regiUser = _context.Users.Single(u => u.Email == User.Identity.Name);

                ugyfelInDb.Nev = ugyfel.Nev;
                ugyfelInDb.Cim = ugyfel.Cim;
                ugyfelInDb.SzuletesiDatum = ugyfel.SzuletesiDatum;
                ugyfelInDb.Jogositvany = ugyfel.Jogositvany;
                ugyfelInDb.Telefonszam = ugyfel.Telefonszam;
                ugyfelInDb.Email = ugyfel.Email;
                regiUser.Email = ugyfel.Email;
            }
            _context.SaveChanges();

            if (User.IsInRole("CanManage"))
                return RedirectToAction("Index", "Ugyfelek");
            else
                return View("UgyfelLista", ugyfel);
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

        [Authorize]
        public ActionResult New()
        {
            var ugyfel = new Ugyfel { Id = 0 };
            return View("UgyfelForm", ugyfel);
        }
    }
}