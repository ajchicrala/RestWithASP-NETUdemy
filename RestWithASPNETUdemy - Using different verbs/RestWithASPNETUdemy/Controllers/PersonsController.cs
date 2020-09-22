using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {

        private IPersonInterface _personservice;

        public PersonsController(IPersonInterface personservice)
        {
            _personservice = personservice;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personservice.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personservice.FindById(id);
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
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) BadRequest();
            return new ObjectResult(_personservice.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personservice.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personservice.Delete(id);
            return NoContent();
        }


    }
}
