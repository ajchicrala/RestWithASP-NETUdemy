using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {


        // GET api/values/5/5
        [HttpGet("{firstnumber}/{secondnumber}")]
        public IActionResult Sum(string firstnumber, string secondnumber)
        {
            try
            {
                var total = Convert.ToDecimal(firstnumber) + Convert.ToDecimal(secondnumber);
                return Ok(total.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid Input");
            }

        }


    }
}
