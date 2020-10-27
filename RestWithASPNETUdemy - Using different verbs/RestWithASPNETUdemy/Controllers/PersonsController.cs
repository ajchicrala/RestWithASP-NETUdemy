using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
using Tapioca.HATEOAS;

namespace RestWithASPNETUdemy.Controllers
{

    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonsController : ControllerBase
    {

        private IPersonBusiness _personbusiness;

        public PersonsController(IPersonBusiness personbusiness)
        {
            _personbusiness = personbusiness;
        }

        // GET api/values
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personbusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _personbusiness.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(person);
            }
                
        }

        // POST api/values
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) BadRequest();
            return new ObjectResult(_personbusiness.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personbusiness.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(long id)
        {
            _personbusiness.Delete(id);
            return NoContent();
        }


    }
}
