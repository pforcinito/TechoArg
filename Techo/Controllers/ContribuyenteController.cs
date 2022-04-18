using Microsoft.AspNetCore.Mvc;
using Techo.Contracts;
using Techo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techo.Controllers
{
    public class ContribuyenteController : Controller
    {
        private readonly IContribuyenteService _service;

        public ContribuyenteController(IContribuyenteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var res = _service.GetAll();

            if (res != null)
                return Ok(res);

            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(short id)
        {
            var res = _service.GetById(id);

            if (res != null)
                return Ok(res);

            return NotFound();
        }

        [HttpPut]
        public IActionResult SaveContribuyente(Contribuyente contribuyente)
        {
            var res = _service.Save(contribuyente);

            if (res != 0)
                return Ok(res);

            return BadRequest();
        }

        public IActionResult UpdateContribuyente(Contribuyente contribuyente)
        {
            var res = _service.Update(contribuyente);

            if (res)
                return Ok(res);

            return BadRequest();
        }
    }
}
