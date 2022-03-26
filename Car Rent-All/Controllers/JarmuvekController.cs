using AutoMapper;
using Car_Rent_All.Models;
using Car_Rent_All.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            if (User.IsInRole("CanManage"))
                return View("AdminLista");
            else
                return View("UgyfelLista");
        }

        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult JarmuForm()
        {
            var jarmu = new Jarmu { Id = 0 };

            var viewModel = new JarmuValtoUzemanyag
            {
                Jarmu = jarmu,
                Valto = _context.Valtok.ToList(),
                Uzemanyag = _context.Uzemanyagok.ToList()
            };

            return View(viewModel);
        }

        [Authorize(Roles = RoleName.CanManage)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Jarmu jarmu)
        {
            if (!ModelState.IsValid)
            {
                var visszaadottJarmu = jarmu;
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
                _context.Jarmuvek.Add(jarmu);
            }
            else
            {
                var jarmuInDb = _context.Jarmuvek.Single(j => j.Id == jarmu.Id);
                Mapper.Map(jarmu, jarmuInDb);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Jarmuvek");
        }

        [Authorize(Roles = RoleName.CanManage)]
        public ActionResult Edit(int id)
        {
            var jarmu = _context.Jarmuvek.SingleOrDefault(u => u.Id == id);
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
        public ActionResult New()
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
    }
}