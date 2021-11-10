using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VersioningService.Core.Interfaces.Services;
using VersioningService.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VersioningService.V2.Controllers
{
    //[Route("api/" + ApiConstants.ServiceName + "/v{api-version:apiVersion}/[controller]")]
    // [Route("api/" + ApiConstants.ServiceName + "/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MicrofrontEndsController : Controller
    {
        private readonly IMicrofrontEndService _mfeService;

        public MicrofrontEndsController(IMicrofrontEndService mfeService)
        {
            _mfeService = mfeService ?? throw new ArgumentNullException(nameof(mfeService));
        }
        // GET: api/values
        [HttpGet]
        // [SwaggerOperation("GetMicrofrontEnds")]
        // [Route("getMicrofrontEnds")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]// (typeof(ApiErrorResponse), 401)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MicrofronEnd>>> Get()
        {
            // throw new Exception($"Error while trying to call GetMicrofrontends method");
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
