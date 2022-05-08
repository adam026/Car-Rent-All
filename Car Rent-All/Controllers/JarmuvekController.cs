using AutoMapper;
using Car_Rent_All.DTOS;
using Car_Rent_All.Models;
using Car_Rent_All.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Car_Rent_All.Controllers
{
    public class JarmuvekController : Controller
    {
        private ApplicationDbContext _context;

        public JarmuvekController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // GET: Jarmuvek
        public ActionResult Index()
        {
            var jarmuvek = _context.Jarmuvek
                .Include(v => v.Valto)
                .Include(u => u.Uzemanyag)
                .ToList();

            var elerheto = _context.Jarmuvek
                .Include(v => v.Valto)
                .Include(u => u.Uzemanyag)
                .Where(e => e.Elerheto == 1)
                .ToList();

            if (User.IsInRole("CanManage"))
                return View("AdminLista");
            else
                return View("BerelhetoJarmuvek", elerheto);
        }

        [Authorize(Roles = RoleName.CanManage)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Mentes(Jarmu jarmu)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new JarmuValtoUzemanyag
                {
                    Jarmu = jarmu,
                    Valto = _context.Valtok.ToList(),
                    Uzemanyag = _context.Uzemanyagok.ToList()
                };

                return View("JarmuForm", viewModel);
            }


            if (jarmu.Id == 0)
            {
                jarmu.Elerheto = 1;
                _context.Jarmuvek.Add(jarmu);
            }
            else
            {
                var jarmuInDb = _context.Jarmuvek.Single(j => j.Id == jarmu.Id);

                jarmuInDb.Nev = jarmu.Nev;
                jarmuInDb.Rendszam = jarmu.Rendszam;
                jarmuInDb.Alvazszam = jarmu.Alvazszam;
                jarmuInDb.valtoId = jarmu.valtoId;
                jarmuInDb.UzemanyagId = jarmu.UzemanyagId;
                jarmuInDb.Ajtok = jarmu.Ajtok;
                jarmuInDb.Ar = jarmu.Ar;
                jarmuInDb.GyartasEve = jarmu.GyartasEve;
                jarmuInDb.Kep = jarmu.Kep;
                jarmuInDb.Elerheto = jarmu.Elerheto;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Jarmuvek");
        }

        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult Szerkesztes(int id)
        {
            var jarmu = _context.Jarmuvek
                .Include(v => v.Valto)
                .Include(u => u.Uzemanyag)
                .SingleOrDefault(j => j.Id == id);

            if (jarmu is null)
                return HttpNotFound();

            var viewModel = new JarmuValtoUzemanyag()
            {
                Jarmu = jarmu,
                Valto = _context.Valtok.ToList(),
                Uzemanyag = _context.Uzemanyagok.ToList()
            };

            return View("JarmuForm", viewModel);

        }

        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult UjJarmu()
        {
            var jarmu = new Jarmu { Id = 0 };
            var viewModel = new JarmuValtoUzemanyag
            {
                Jarmu = jarmu,
                Valto = _context.Valtok.ToList(),
                Uzemanyag = _context.Uzemanyagok.ToList()
            };
            return View("JarmuForm", viewModel);
        }

        public ActionResult Reszletek(int id)
        {
            var jarmu = _context.Jarmuvek
                .Include(v => v.Valto)
                .Include(u => u.Uzemanyag)
                .Single(j => j.Id == id);

            return View("Reszletek", jarmu);
        }
    }
}
