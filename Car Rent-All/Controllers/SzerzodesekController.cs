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
                .Include(u => u.Ugyfel)
                .Include(v => v.Jarmu.Valto)
                .Include(u => u.Jarmu.Uzemanyag)
                .ToList();

                return View("IndexAdmin", szerzodesekAdmin);
            }

            var ugyfel = _context.Ugyfelek.Single(u => u.Email == User.Identity.Name);
            var szerzodesek = _context.Szerzodesek
                .Include(j => j.Jarmu)
                .Where(u => u.UgyfelId == ugyfel.Id).ToList();
            
            return View("IndexUgyfel", szerzodesek);
        }

        public ActionResult UjSzerzodes(Jarmu jarmu)
        {
            var ugyfel = _context.Ugyfelek.SingleOrDefault(u => u.Email == User.Identity.Name);
            if (ugyfel == null) 
                return RedirectToAction("Index", "Ugyfelek");

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

            return View("UjSzerzodes", viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Mentes(Szerzodes szerzodes)
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

                return View("UjSzerzodes", viewModel);
            }


            if (szerzodes.Id != 0)
            {
                _context.Szerzodesek.Add(szerzodes);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Szerzodesek");
        }

        public ActionResult Jovahagy(int id)
        {
            var szerzodesInDb = _context.Szerzodesek.Single(sz => sz.Id == id);
            if (szerzodesInDb.Jovahagy == 1)
                szerzodesInDb.Jovahagy = 0;
            else
                szerzodesInDb.Jovahagy = 1;

            _context.SaveChanges();

            return RedirectToAction("Index", "Szerzodesek");
        }

        public ActionResult ArchivumhozAd(int id)
        {
            var szerzodes = _context.Szerzodesek
                .Include(u => u.Ugyfel)
                .Include(j => j.Jarmu)
                .Single(sz => sz.Id == id);

            var archivum = new Archivum
            {
                SzerzodesId = szerzodes.Id,
                UgyfelNeve = szerzodes.Ugyfel.Nev,
                UgyfelCime = szerzodes.Ugyfel.Cim,
                UgyfelEmail = szerzodes.Ugyfel.Email,
                UgyfelJogositvany = szerzodes.Ugyfel.Jogositvany,
                UgyfelSzuletesiDatum = szerzodes.Ugyfel.SzuletesiDatum,
                UgyfelTelefonszam = szerzodes.Ugyfel.Telefonszam,
                JarmuNev = szerzodes.Jarmu.Nev,
                JarmuAlvazszam = szerzodes.Jarmu.Alvazszam,
                JarmuRendszam = szerzodes.Jarmu.Rendszam,
                JarmuGyartasEve = szerzodes.Jarmu.GyartasEve,
                BerlesKezdoIdopont = szerzodes.BerlesKezdoIdopont,
                BerlesZaroIdopont = szerzodes.BerlesZaroIdopont,
                BefizetettOsszeg = (szerzodes.BerlesZaroIdopont.Day - szerzodes.BerlesZaroIdopont.Day) * szerzodes.Jarmu.Ar,
                Megjegyzes = null
            };

            _context.ArchivaltSzerzodesek.Add(archivum);
            _context.Szerzodesek.Remove(szerzodes);

            _context.SaveChanges();

            return RedirectToAction("ArchivaltSzerzodesek", "Szerzodesek");
        }

        public ActionResult ArchivaltSzerzodesek()
        {
            var archivaltSzerzodesek = _context.ArchivaltSzerzodesek.ToList();
            return View(archivaltSzerzodesek);
        }
    }

}