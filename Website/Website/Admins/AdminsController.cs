using Microsoft.AspNetCore.Mvc;
using Website.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Website.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {

        private readonly DA5_QLdayhocContext _context;
        public AdminsController(DA5_QLdayhocContext context)
        {
            _context = context;
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            var result = _context.Sinhviens;
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest();
        }

        // GET api/<LophocsController>/5
        [HttpGet("class")]
        public IActionResult ChiTietLop()
        {

            var result = _context.Lophocs.ToList();
            return Ok(result);
        }
        // GET: api/<AdminsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AdminsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdminsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
