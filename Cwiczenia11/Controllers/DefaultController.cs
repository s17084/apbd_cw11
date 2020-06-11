using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenia11.Models;
using Cwiczenia11.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IDbService _service;
        public DefaultController(IDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_service.GetDoctors());
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            return Ok(_service.GetDoctor(id));
        }

        [HttpPost("add")]
        public IActionResult AddDoctor(AddDoctorRequest req)
        {
            _service.AddDoctor(req);
            return Ok();
        }
        
        [HttpPatch("update/{id}")]
        public IActionResult UpdateDoctor(AddDoctorRequest req, int id)
        {
            _service.UpdateDoctor(req, id);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            _service.DeleteDoctor(id);
            return Ok();
        }
    }
}