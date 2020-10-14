using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : ControllerBase
    {

        private IBooksBusiness _booksbusiness;

        public BooksController(IBooksBusiness booksbusiness)
        {
            _booksbusiness = booksbusiness;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksbusiness.FindAll());
            //return Ok();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var books = _booksbusiness.FindById(id);
            if (books == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(books);
            }
            //return Ok();

        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Books book)
        {
            if (book == null) BadRequest();
            return new ObjectResult(_booksbusiness.Create(book));
            //return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Books book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_booksbusiness.Update(book));
            //return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _booksbusiness.Delete(id);
            return NoContent();
            //return Ok();
        }

    }
}
