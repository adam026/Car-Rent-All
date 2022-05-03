using Car_Rent_All.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

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
                    return RedirectToAction("UjUgyfel", "Ugyfelek");
                else
                    return View("UgyfelLista", meghivoUgyfel);
            }

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Mentes(Ugyfel ugyfel)
        {
            if (!ModelState.IsValid)
            {

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

                ugyfelInDb.Nev = ugyfel.Nev;
                ugyfelInDb.Cim = ugyfel.Cim;
                ugyfelInDb.SzuletesiDatum = ugyfel.SzuletesiDatum;
                ugyfelInDb.Jogositvany = ugyfel.Jogositvany;
                ugyfelInDb.Telefonszam = ugyfel.Telefonszam;
                ugyfelInDb.Email = ugyfel.Email;

            }
            _context.SaveChanges();

            if (User.IsInRole("CanManage"))
                return RedirectToAction("Index", "Ugyfelek");
            else
                return View("UgyfelLista", ugyfel);
        }

        public ActionResult Szerkesztes(int id)
        {
            var ugyfel = _context.Ugyfelek.SingleOrDefault(u => u.Id == id);
            if (ugyfel is null) 
                return HttpNotFound();
            else
            {
                return View("UgyfelForm", ugyfel);
            }
        }

        [Authorize]
        public ActionResult UjUgyfel()
        {
            var ugyfel = new Ugyfel { Id = 0 };
            return View("UgyfelForm", ugyfel);
        }
    }
}