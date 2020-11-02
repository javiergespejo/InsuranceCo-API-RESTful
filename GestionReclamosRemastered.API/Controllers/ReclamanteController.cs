using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GestionReclamosRemastered.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReclamanteController : ControllerBase
    {
        // GET: api/<ReclamanteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ReclamanteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReclamanteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReclamanteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReclamanteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
