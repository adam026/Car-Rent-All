using AutoMapper;
using Car_Rent_All.DTOS;
using Car_Rent_All.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Car_Rent_All.Controllers.Api
{
    public class JarmuvekController : ApiController
    {
        private ApplicationDbContext _context;

        public JarmuvekController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/jarmuvek

        public IHttpActionResult GetJarmuvek()
        {
            var jarmuDTOk = _context.Jarmuvek
                .Include(v => v.Valto)
                .Include(u => u.Uzemanyag)
                .ToList()
                .Select(Mapper.Map<Jarmu, JarmuDTO>);

            return Ok(jarmuDTOk);
        }

        //GET /api/jarmuvek/id

        [Authorize(Roles = RoleName.CanManage)]
        public IHttpActionResult GetJarmu(int id)
        {
            var jarmu = _context.Jarmuvek.SingleOrDefault(j => j.Id == id);

            if (jarmu == null)
                return NotFound();
            return Ok(Mapper.Map<Jarmu, JarmuDTO>(jarmu));
        }

        //POST /api/jarmuvek

        [Authorize(Roles = RoleName.CanManage)]
        [HttpPost]
        public IHttpActionResult CreateJarmu(JarmuDTO jarmuDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var jarmu = Mapper.Map<JarmuDTO, Jarmu>(jarmuDTO);
            _context.Jarmuvek.Add(jarmu);
            _context.SaveChanges();

            jarmuDTO.Id = jarmu.Id;

            return Created(new Uri(Request.RequestUri + $"/{jarmu.Id}"), jarmu);
        }
        //PUT /api/jarmuvek/id

        [Authorize(Roles = RoleName.CanManage)]
        [HttpPut]
        public IHttpActionResult UpdateJarmu(int id, JarmuDTO jarmuDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var jarmuInDb = _context.Jarmuvek.SingleOrDefault(j => j.Id == id);

            if (jarmuInDb == null)
                return NotFound();

            Mapper.Map(jarmuDTO, jarmuInDb);

            _context.SaveChanges();

            return Ok();
        }
        //DELETE /api/jarmuvek/id

        [Authorize(Roles = RoleName.CanManage)]
        [HttpDelete]
        public IHttpActionResult DeleteJarmu(int id)
        {
            var jarmuInDb = _context.Jarmuvek.SingleOrDefault(j => j.Id == id);

            if (jarmuInDb == null)
                return NotFound();

            _context.Jarmuvek.Remove(jarmuInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}

