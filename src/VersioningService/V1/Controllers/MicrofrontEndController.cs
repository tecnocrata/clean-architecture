using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VersioningService.Core.Interfaces.Services;
using VersioningService.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VersioningService.V1.Controllers
{
    [Route("api/[controller]")]
    public class MicrofrontEndController : Controller
    {
        private readonly IMicrofrontEndService _mfeService;

        public MicrofrontEndController(IMicrofrontEndService mfeService)
        {
            _mfeService = mfeService ?? throw new ArgumentNullException(nameof(mfeService));
        }
        // GET: api/values
        [HttpGet]

        public async Task<ActionResult<IEnumerable<MicrofronEnd>>> Get()
        {
            var response = await _mfeService.GetAllMicrofrontEnds();
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
