using AutoMapper;
using Car_Rent_All.DTOS;
using Car_Rent_All.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Car_Rent_All.Controllers.Api
{
    public class UgyfelekController : ApiController
    {
        private ApplicationDbContext _context;

        public UgyfelekController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/ugyfelek

        [Authorize(Roles = RoleName.CanManage)]
        public IHttpActionResult GetUgyfelek()
        {
            return Ok(_context.Ugyfelek.ToList().Select(Mapper.Map<Ugyfel,UgyfelDTO>));
        }

        //GET /api/ugyfelek/id

        [Authorize(Roles = RoleName.CanManage)]
        public IHttpActionResult GetUgyfel(int id)
        {
            var ugyfel = _context.Ugyfelek.SingleOrDefault(u => u.Id == id);

            if (ugyfel == null)
                return NotFound();
            return Ok(Mapper.Map<Ugyfel,UgyfelDTO>(ugyfel));
        }

        //POST /api/ugyfelek

        [Authorize(Roles = RoleName.CanManage)]
        [HttpPost]
        public IHttpActionResult CreateUgyfel(UgyfelDTO ugyfelDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ugyfel = Mapper.Map<UgyfelDTO, Ugyfel>(ugyfelDTO);
            _context.Ugyfelek.Add(ugyfel);
            _context.SaveChanges();

            ugyfelDTO.Id = ugyfel.Id;

            return Created(new Uri(Request.RequestUri + $"/{ugyfel.Id}"), ugyfel);
        }
        //PUT /api/ugyfelek/id

        [Authorize(Roles = RoleName.CanManage)]
        [HttpPut]
        public IHttpActionResult UpdateUgyfel(int id, UgyfelDTO ugyfelDTO) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ugyfelInDb = _context.Ugyfelek.SingleOrDefault(u => u.Id == id);

            if (ugyfelInDb == null)
                return NotFound();

            Mapper.Map(ugyfelDTO, ugyfelInDb);

            _context.SaveChanges();

            return Ok();
        }
        //DELETE /api/ugyfelek/id

        [Authorize(Roles = RoleName.CanManage)]
        [HttpDelete]
        public IHttpActionResult DeleteUgyfel(int id)
        {
            var ugyfelInDb = _context.Ugyfelek.SingleOrDefault(u => u.Id == id);

            if (ugyfelInDb == null)
                return NotFound();

            _context.Ugyfelek.Remove(ugyfelInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
