using Car_Rent_All.Models;
using Car_Rent_All.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Car_Rent_All.Controllers
{
    public class SzerzodesekController : Controller
    {
        private ApplicationDbContext _context;

        public SzerzodesekController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // GET: Szerzodesek
        public ActionResult Index()
        {
            if (User.IsInRole("CanManage"))
            {
                var szerzodesekAdmin = _context.Szerzodesek
                .Include(j => j.Jarmu)
                .ToList();

                return View("IndexAdmin", szerzodesekAdmin);
            }

            var ugyfel = _context.Ugyfelek.Single(u => u.Email == User.Identity.Name);
            var szerzodesek = _context.Szerzodesek
                .Include(j => j.Jarmu)
                .Where(u => u.UgyfelId == ugyfel.Id).ToList();
            
            return View("IndexUgyfel", szerzodesek);
        }

        public ActionResult New(Jarmu jarmu)
        {
            var ugyfel = _context.Ugyfelek.Single(u => u.Email == User.Identity.Name);
            var jarmuBerleshez = _context.Jarmuvek
                .Include(v => v.Valto)
                .Include(u => u.Uzemanyag)
                .Single(j => j.Id == jarmu.Id);

            var viewModel = new Szerzodes
            {
                UgyfelId = ugyfel.Id,
                JarmuId = jarmu.Id,
                Jarmu = jarmuBerleshez,
                Ugyfel = ugyfel
            };

            return View("New", viewModel);
        }

        public ActionResult Save(Szerzodes szerzodes)
        {
            if (!ModelState.IsValid)
            {
                var jarmuVissza = _context.Jarmuvek
                    .Include(v => v.Valto)
                    .Include(u => u.Uzemanyag)
                    .Single(j => j.Id == szerzodes.Jarmu.Id);

                var ugyfelVissza = _context.Ugyfelek.Single(u => u.Id == szerzodes.Ugyfel.Id);

                var viewModel = new Szerzodes
                {
                    Jarmu = jarmuVissza,
                    Ugyfel = ugyfelVissza,
                    BerlesKezdoIdopont = szerzodes.BerlesKezdoIdopont,
                    BerlesZaroIdopont = szerzodes.BerlesZaroIdopont
                };

                return View("New", viewModel);
            }


            if (szerzodes.Id != 0)
            {
                _context.Szerzodesek.Add(szerzodes);
            }
            else
            {
                //Kiegészíteni
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Szerzodesek");
        }
    }

}